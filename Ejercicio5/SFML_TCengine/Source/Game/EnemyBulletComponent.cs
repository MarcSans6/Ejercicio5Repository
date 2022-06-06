using TCEngine;

namespace TCGame
{
    public class EnemyBulletComponent : BaseComponent
    {
        public EnemyBulletComponent()
        {
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            MainCharacterControllerComponent mainCharacterControllerComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<MainCharacterControllerComponent>();

            if (mainCharacterControllerComponent.Owner.GetGlobalBounds().Intersects(Owner.GetGlobalBounds()))
            {

                Owner.Destroy();

                HUDComponent hudComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<HUDComponent>();
                if (hudComponent != null)
                {
                }
            }
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            MainWeaponComponent clonedComponent = new MainWeaponComponent();
            return clonedComponent;
        }
    }
}
