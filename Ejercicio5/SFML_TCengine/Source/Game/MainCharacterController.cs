using SFML.System;
using SFML.Window;
using TCEngine;

namespace TCGame    
{
    class MainCharacterController: BaseComponent
    {
        private const float MOVEMENT_SPEED = 200f;

        private Vector2f m_dir;

        public MainCharacterController()
        {
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return BaseComponent.EComponentUpdateCategory.PreUpdate;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            m_dir = new Vector2f(0, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                m_dir += new Vector2f(0, -1);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                m_dir += new Vector2f(-1, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                m_dir += new Vector2f(0, 1);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                m_dir += new Vector2f(1, 0);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                if (Owner.GetComponent<WeaponComponent>() != null)
                {
                    Owner.GetComponent<WeaponComponent>().Shoot();
                }
            }

            m_dir = m_dir.Normal();

            Owner.GetComponent<TransformComponent>().Transform.Position += m_dir * MOVEMENT_SPEED * _dt;
        }
    }
}
