using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCEngine;

namespace TCGame
{
    class DeathOutsideWallsComponent : BaseComponent
    {
        public DeathOutsideWallsComponent()
        {
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            ScenarioComponent scenario = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();

            FloatRect ownerBounds = Owner.GetGlobalBounds();

            if (scenario != null)
            {
                if (scenario.TopFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y) || scenario.BotFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y) || scenario.LeftFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y) || scenario.RightFrameBounds.Contains(Owner.GetPosition().X, Owner.GetPosition().Y))
                {
                    Owner.Destroy();
                }
            }
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            TargetComponent clonedComponent = new TargetComponent();
            return clonedComponent;
        }
    }
}
