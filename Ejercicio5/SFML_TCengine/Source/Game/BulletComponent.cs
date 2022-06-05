using TCEngine;

namespace TCGame
{
    public class BulletComponent : BaseComponent
    {
        public BulletComponent()
        {
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            foreach (TargetComponent targetComponent in TecnoCampusEngine.Get.Scene.GetAllComponents<TargetComponent>())
            {
                if( targetComponent.Owner.GetGlobalBounds().Intersects(Owner.GetGlobalBounds()))
                {

                    targetComponent.Owner.GetComponent<HealthComponent>().TakeDmg(1.0f);
                    Owner.Destroy();

                    HUDComponent hudComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<HUDComponent>();
                    if (hudComponent != null)
                    {
                    }
                }
            }
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public override object Clone()
        {
            WeaponComponent clonedComponent = new WeaponComponent();
            return clonedComponent;
        }
    }
}
