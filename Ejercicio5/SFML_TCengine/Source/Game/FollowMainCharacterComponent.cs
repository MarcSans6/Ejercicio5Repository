using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    class FollowMainCharacterComponent : BaseComponent
    {
        private float m_DEAFULT_SPEED;
        private float m_Speed;
        private Vector2f m_Forward;
        public FollowMainCharacterComponent(float _speed)
        {
            m_DEAFULT_SPEED = _speed;
            m_Speed = m_DEAFULT_SPEED;
        }

        public enum State
        {
            Follow,
            Attack
        }

        public State currentState = State.Follow;

        public override void Update(float _dt)
        {
            base.Update(_dt);

            Owner.GetComponent<TransformComponent>().Transform.Position += new Vector2f(1, 0) * 200.0f * _dt;

            switch (currentState)
            {
                case State.Follow:
                    UpdateFollow(_dt);
                    break;
                case State.Attack:
                    UpdateAttack(_dt);
                    break;
            }

        }

        private void UpdateFollow(float _dt)
        {
            Vector2f ownerMainOffset = TecnoCampusEngine.Get.Scene.GetFirstComponent<MainCharacterControllerComponent>().Owner.GetPosition() - Owner.GetPosition();

            if (ownerMainOffset.Size() < 50.0f)
            {
                ChangeState(State.Attack);
            }

            ownerMainOffset.Normal();

            m_Forward = ownerMainOffset;

            Owner.GetComponent<TransformComponent>().Transform.Position += m_Forward * m_Speed * _dt;
        }

        private void UpdateAttack(float _dt)
        {
            Vector2f ownerMainOffset = TecnoCampusEngine.Get.Scene.GetFirstComponent<MainCharacterControllerComponent>().Owner.GetPosition() - Owner.GetPosition();

            if (ownerMainOffset.Size() >= 50.0f)
            {
                ChangeState(State.Follow);
            }

            ownerMainOffset.Normal();

            m_Forward = ownerMainOffset;

            WeaponComponent weaponComponent = Owner.GetComponent<WeaponComponent>();
            weaponComponent.Shoot(m_Forward, 700.0f);
        }

        private void UpdatePosition(float _dt)
        {
            Owner.GetComponent<TransformComponent>().Transform.Position += m_Forward * m_Speed * _dt;
        }

        public void ChangeState(State newState)
        {
            onLeaveState(currentState);
            onEnterState(newState);
            currentState = newState;
        }

        private void onEnterState(State newState)
        {
            switch (newState)
            {
                case State.Follow:

                    m_Speed = m_DEAFULT_SPEED;
                    break;

                case State.Attack:

                    m_Speed = 0;
                    break;
            }
        }

        private void onLeaveState(State oldState)
        {
            switch (currentState)
            {
                case State.Follow:
                    m_Speed = 0.0f;
                    break;

                case State.Attack:
                    m_Speed = m_DEAFULT_SPEED;
                    break;
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
