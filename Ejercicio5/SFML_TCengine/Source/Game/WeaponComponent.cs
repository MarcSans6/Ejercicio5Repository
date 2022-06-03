using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class WeaponComponent : BaseComponent
    {
        private const float DEFAULT_FIRE_RATE = 0.3f;

        private float m_FireRate;
        private float m_TimeToShoot;

        public WeaponComponent()
        {
            m_FireRate = DEFAULT_FIRE_RATE;
            m_TimeToShoot = 0.0f;
        }

        public WeaponComponent(float _fireRate)
        {
            m_FireRate = _fireRate;
            m_TimeToShoot = 0.0f;
        }

        public override void OnActorCreated()
        {
            base.OnActorCreated();
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            if(m_TimeToShoot > 0.0f)
            {
                m_TimeToShoot -= _dt;
            }

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Shoot();
            }

        }

        public void Shoot()
        {
            if (m_TimeToShoot <= 0.0f)
            {
                Actor bulletActor = new Actor("Bullet Actor");

                // Create a Rectangle Shape 
                Shape shape = new RectangleShape(new Vector2f(10.0f, 30.0f));
                shape.FillColor = Color.Transparent;
                shape.OutlineColor = Color.Red;
                shape.OutlineThickness = 2.0f;
                bulletActor.AddComponent<ShapeComponent>(shape);

                // Get the transform of the actor that is owner of this instance of the WeaponComponent
                TransformComponent actorTransform = Owner.GetComponent<TransformComponent>();

                // Add the a TransformComponent to the new bulletActor
                TransformComponent transformComponent = bulletActor.AddComponent<TransformComponent>();

                // Assign the Position and Rotation of the actor that will shoot the bullet (this way, the bullets will appear in the same position as the actor)
                transformComponent.Transform.Position = actorTransform.Transform.Position;
                transformComponent.Transform.Rotation = actorTransform.Transform.Rotation;

                // Get the component where you store the m_Forward information
                AimMouseComponent aimMouseComponent = Owner.GetComponent<AimMouseComponent>();

                // Add the MRUComponent to the bulletActor
                MRUComponent mruComponent = bulletActor.AddComponent<MRUComponent>();
                mruComponent.Forward = aimMouseComponent.Forward;
                mruComponent.Speed = 700.0f;

               
                // Add the BulletComponent to the bulletActor
                bulletActor.AddComponent<BulletComponent>();

                // 4. Add the bulletActor to the Scene
                TecnoCampusEngine.Get.Scene.CreateActor(bulletActor);






                ////////////////////////////////////////////////////////

                m_TimeToShoot = m_FireRate;
            }
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.PostUpdate;
        }

        public override object Clone()
        {
            WeaponComponent clonedComponent = new WeaponComponent(m_FireRate);
            return clonedComponent;
        }
    }
}
