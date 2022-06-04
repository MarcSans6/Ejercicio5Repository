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
        private const float BULLET_SPEED = 100;
        private float m_Speed;
        private Vector2f bullet_Forward;
        private Vector2f refactor_Forward;

        // Getters and Setters of Speed, bullet Forward, refactor Forward
        public float Speed
        {
            get => m_Speed;
            set => m_Speed = value;
        }

        public Vector2f BulletDirection
        {
            get => bullet_Forward;
            set => bullet_Forward = value;
        }

        public Vector2f RefractDirection
        {
            get => refactor_Forward;
            set => refactor_Forward = value;
        }
        // Constructor without parametres 
        public BounceComponent()
        {
            Speed = BULLET_SPEED;
        }


        public override void Update(float _dt)
        {
            base.Update(_dt);

            // Calaculate the refractor forward

            TransformComponent bulletTransformComponent = Owner.GetComponent<TransformComponent>();
            bulletTransformComponent.Transform.Position = bullet_Forward;

            foreach (BulletComponent bulletComponent in TecnoCampusEngine.Get.Scene.GetAllComponents<BulletComponent>())
            {
                if (bulletComponent.Owner.GetGlobalBounds().Contains(TecnoCampusEngine.Get.ViewportSize.X, TecnoCampusEngine.Get.ViewportSize.Y))
                {
                    refactor_Forward = new Vector2f(bullet_Forward.X * -1, bullet_Forward.Y * -1);
                }
            }

            Owner.GetComponent<TransformComponent>().Transform.Position += refactor_Forward * Speed * _dt;
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
