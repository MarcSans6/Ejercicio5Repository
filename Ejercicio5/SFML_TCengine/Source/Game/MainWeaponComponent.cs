using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class MainWeaponComponent : BaseComponent
    {
        private const float DEFAULT_FIRE_RATE = 0.15f;

        private float m_FireRate;
        private float m_TimeToShoot;

        public MainWeaponComponent()
        {
            m_FireRate = DEFAULT_FIRE_RATE;
            m_TimeToShoot = 0.0f;
        }

        public MainWeaponComponent(float _fireRate)
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

        }

        public void Shoot(Vector2f _forward, float _speed)
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

                // Add the MRUComponent to the bulletActor
                MRUComponent mruComponent = bulletActor.AddComponent<MRUComponent>();
                mruComponent.Forward = _forward;
                mruComponent.Speed = _speed;

               
                // Add the BulletComponent to the bulletActor
                bulletActor.AddComponent<BulletComponent>();
                bulletActor.AddComponent<DeathOutsideWallsComponent>();

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
            MainWeaponComponent clonedComponent = new MainWeaponComponent(m_FireRate);
            return clonedComponent;
        }
    }
}
