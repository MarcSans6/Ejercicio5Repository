using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class AimMouseComponent : BaseComponent
    {
        private const float DEFAULT_ANGULAR_SPEED = 360.0f;
        private static Vector2f UP_VECTOR = new Vector2f(0.0f, -1.0f);

        private Vector2f m_DesiredForward;
        private Vector2f m_MousePosition;
        private Vector2f m_Forward;

        private float m_AngularSpeed = DEFAULT_ANGULAR_SPEED;

        public Vector2f Forward
        {
            get => m_Forward;
            set => m_Forward = value;
        }
       
        public float AngularSpeed
        {
            get => m_AngularSpeed;
            set => m_AngularSpeed = value;
        }

        public AimMouseComponent()
        {
            m_Forward = UP_VECTOR;
            m_MousePosition = new Vector2f(0.0f, 0.0f);
            m_DesiredForward = new Vector2f();
            m_AngularSpeed = DEFAULT_ANGULAR_SPEED;
        }

        public AimMouseComponent(Vector2f _forward)
        {
            m_Forward = _forward;
            m_MousePosition = new Vector2f(0.0f, 0.0f);
            m_DesiredForward = new Vector2f();
            m_AngularSpeed = DEFAULT_ANGULAR_SPEED;
        }

        public AimMouseComponent(Vector2f _forward, float _angularSpeed)
        {
            m_Forward = _forward;
            m_MousePosition = new Vector2f(0.0f, 0.0f);
            m_DesiredForward = new Vector2f();
            m_AngularSpeed = _angularSpeed;
        }

        public override void OnActorCreated()
        {
            base.OnActorCreated();

            TecnoCampusEngine.Get.Window.MouseMoved += MouseMovedHandler;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            TransformComponent transformComponent = Owner.GetComponent<TransformComponent>();
            Debug.Assert(transformComponent != null);

            //rotate
            float angle = MathUtil.AngleWithSign(m_Forward, UP_VECTOR);
            transformComponent.Transform.Rotation = angle;

            // Calculate the desired forward
            Vector2f objectToMouseOffset = m_MousePosition - transformComponent.Transform.Position;
            m_DesiredForward = objectToMouseOffset.Normal();

            // Calculate the angle difference between the current forward and the new desired forward
            float angleToDesiredForward = MathUtil.Angle(m_DesiredForward, m_Forward);
            float angleToRotate = m_AngularSpeed * _dt;
            if (angleToRotate > angleToDesiredForward)
            {
                angleToRotate = angleToDesiredForward;
            }

            // Calculate the sign (do we have to rotate to the right or to the left?)
            float sign = MathUtil.Sign(m_DesiredForward, m_Forward);
            angleToRotate = angleToRotate * sign;

            // Calculate the real forward
            m_Forward = m_Forward.Rotate(angleToRotate);


        }

        private void MouseMovedHandler(object _sender, MouseMoveEventArgs _mouseEventArgs)
        {
            m_MousePosition = new Vector2f(_mouseEventArgs.X, _mouseEventArgs.Y);
        }

        public override void DebugDraw()
        {
            base.DebugDraw();
            TecnoCampusEngine.Get.DebugManager.Label(new Vector2f(50, 50), m_MousePosition.ToString(), Color.Green);
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            AimMouseComponent clonedComponent = new AimMouseComponent(m_Forward, m_AngularSpeed);
            return clonedComponent;
        }
    }
}
