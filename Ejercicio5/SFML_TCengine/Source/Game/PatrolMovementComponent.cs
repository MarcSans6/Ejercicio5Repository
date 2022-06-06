using SFML.System;
using System.Diagnostics;
using TCEngine;
using System;

namespace TCGame
{
    class PatrolMovementComponent: BaseComponent
    {
        private float DEFAULT_SPEED;
        private float m_Speed;
        private Vector2f m_Forward;

        public PatrolMovementComponent(float _speed)
        {
            DEFAULT_SPEED = _speed;
            m_Speed = DEFAULT_SPEED;
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

            switch (currentState)
            {
                case State.Follow:
                    UpdateFollow(_dt);
                    break;
                case State.Attack:
                    UpdateAttack(_dt);
                    break;
            }

            UpdatePosition(_dt);
        }

        private void UpdateFollow(float _dt)
        {
            if (CalculateOffSet().Size() < 150.0f)
            {
                ChangeState(State.Attack);
            }

            m_Forward = CalculateOffSet().Normal();
        }

        private void UpdateAttack(float _dt)
        {
            if (CalculateOffSet().Size() >= 150.0f)
            {
                ChangeState(State.Follow);
            }
            
            m_Forward = CalculateOffSet().Normal();

            EnemyWeaponComponent weaponComponent = Owner.GetComponent<EnemyWeaponComponent>();
            weaponComponent.Shoot(m_Forward, 700.0f);
        }

        private void UpdatePosition(float _dt)
        {
            Owner.GetComponent<TransformComponent>().Transform.Position += m_Speed * m_Forward * _dt;
        }

        private Vector2f CalculateOffSet()
        {
            Vector2f offset = TecnoCampusEngine.Get.Scene.GetFirstComponent<MainCharacterControllerComponent>().Owner.GetPosition() - Owner.GetPosition();
            return offset;
        }

        private void ChangeState(State _newState)
        {
            OnLeaveState(currentState);
            OnEnterState(_newState);
            currentState = _newState;
        }

        private void OnLeaveState(State _oldState)
        {
            switch (currentState)
            {
                case State.Follow:
                    break;
                case State.Attack:
                    break;
            }
        }

        private void OnEnterState(State _newState)
        {
            switch (_newState)
            {
                case State.Follow:
                    m_Speed = DEFAULT_SPEED;
                    break;
                case State.Attack:
                    m_Speed = 0.0f;
                    break;
            }
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            PatrolMovementComponent clonedComponent = new PatrolMovementComponent(DEFAULT_SPEED);
            return clonedComponent;
        }
    }
}
