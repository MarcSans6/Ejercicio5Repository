using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class MRUComponent : BaseComponent
    {
        private const float DEFAULT_SPEED = 400.0f;
        private Vector2f UP_VECTOR = new Vector2f (0, -1);

        private float m_Speed;
        private Vector2f m_Forward;

        public float Speed
        {
            get => m_Speed;
            set => m_Speed = value;
        }

        public Vector2f Forward
        {
            get => m_Forward;
            set => m_Forward = value;
        }

        public MRUComponent()
        {
            m_Speed = DEFAULT_SPEED;
            m_Forward = UP_VECTOR;
        }
        public MRUComponent(float speed, Vector2f forward)
        {
            m_Speed = speed;
            m_Forward = forward;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            //MRU
            Owner.GetComponent<TransformComponent>().Transform.Position += m_Forward * m_Speed * _dt;
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            MRUComponent clonedComponent = new MRUComponent(m_Speed, m_Forward);
            return clonedComponent;
        }
    }
}
