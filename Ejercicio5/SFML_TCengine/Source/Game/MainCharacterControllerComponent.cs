using SFML.Graphics;
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

            m_Speed = DEAFULT_MOVEMENT_SPEED;

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
                if (Owner.GetComponent<MainWeaponComponent>() != null)
                {
                    Owner.GetComponent<MainWeaponComponent>().Shoot(Owner.GetComponent<AimMouseComponent>().Forward , 1100.0f);
                }
            }

            m_Dir = m_Dir.Normal();

            ScenarioComponent scenarioComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();
            Vector2f newPosition = Owner.GetComponent<TransformComponent>().Transform.Position + m_Dir * m_Speed * _dt;

            if (CheckPosition(_dt))
            {
                m_Speed = 0.0f;
            }

            Owner.GetComponent<TransformComponent>().Transform.Position += m_Dir * m_Speed * _dt;
        }

        private bool CheckPosition(float _dt)
        {
            FloatRect newOwnerBounds = new FloatRect((Owner.GetComponent<TransformComponent>().Transform.Position + m_Dir * m_Speed * _dt), new Vector2f(Owner.GetGlobalBounds().Width, Owner.GetGlobalBounds().Height));

            ScenarioComponent scenario = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();

            if(scenario.TopFrameBounds.Intersects(newOwnerBounds) || scenario.BotFrameBounds.Intersects(newOwnerBounds) || scenario.LeftFrameBounds.Intersects(newOwnerBounds) || scenario.RightFrameBounds.Intersects(newOwnerBounds))
            {
                return true;
            }

            return false;

        }
    }
}
