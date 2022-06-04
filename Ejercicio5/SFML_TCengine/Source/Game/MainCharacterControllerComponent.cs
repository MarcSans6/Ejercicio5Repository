using SFML.System;
using SFML.Window;
using TCEngine;

namespace TCGame    
{
    class MainCharacterControllerComponent: BaseComponent
    {
        private const float DEAFULT_MOVEMENT_SPEED = 200f;

        private float m_Speed;
        private Vector2f m_Dir;

        public float Speed
        {
            get => m_Speed;
            set => m_Speed = value;
        }
        public MainCharacterControllerComponent()
        {
            m_Speed = DEAFULT_MOVEMENT_SPEED;
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return BaseComponent.EComponentUpdateCategory.PreUpdate;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            m_Dir = new Vector2f(0, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                m_Dir += new Vector2f(0, -1);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                m_Dir += new Vector2f(-1, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                m_Dir += new Vector2f(0, 1);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                m_Dir += new Vector2f(1, 0);

            }
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                if (Owner.GetComponent<WeaponComponent>() != null)
                {
                    Owner.GetComponent<WeaponComponent>().Shoot();
                }
            }

            m_Dir = m_Dir.Normal();

            Owner.GetComponent<TransformComponent>().Transform.Position += m_Dir * m_Speed * _dt;
        }
    }
}
