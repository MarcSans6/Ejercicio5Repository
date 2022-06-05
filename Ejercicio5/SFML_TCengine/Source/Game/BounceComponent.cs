using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using TCEngine;

namespace TCGame
{
    public class BounceComponent: BaseComponent
    {

        private float m_AngularSpeed = 360.0f;
        private Vector2f m_Dir;
        private Vector2f m_RefractedDir;

        // Constructor without parametres 
        public BounceComponent()
        {
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            TransformComponent transformComponent = Owner.GetComponent<TransformComponent>();
            m_Dir = Owner.GetComponent<MRUComponent>().Forward;

            m_RefractedDir = m_Dir;

            ScenarioComponent scenario = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();

            FloatRect ownerBounds = Owner.GetGlobalBounds();

            if (scenario != null)
            {
                if (scenario.TopFrameBounds.Contains(Owner.GetPosition().X,Owner.GetPosition().Y) || scenario.BotFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y))
                {
                    m_RefractedDir = new Vector2f(m_Dir.X, - m_Dir.Y);
                }
                if (scenario.LeftFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y) || scenario.RightFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y))
                {
                    m_RefractedDir = new Vector2f(- m_Dir.X, m_Dir.Y);
                }
            }

            Owner.GetComponent<MRUComponent>().Forward = m_RefractedDir;

            float desiredAngle = MathUtil.AngleWithSign(m_Dir, m_RefractedDir);

            transformComponent.Transform.Rotation += desiredAngle;

        }

        
        
        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            BounceComponent clonedComponent = new BounceComponent();
            return clonedComponent;
        }
    }
}
