using SFML.Graphics;
using SFML.System;
using System;
using TCEngine;

namespace TCGame
{
    class DestroyIfWallContactComponent : BaseComponent
    {
        public DestroyIfWallContactComponent()
        {

        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            ScenarioComponent scenarioComponent = TecnoCampusEngine.Get.Scene.GetFirstComponent<ScenarioComponent>();

            if (scenarioComponent != null)
            {
                if (!Owner.GetGlobalBounds().Intersects(scenarioComponent.Screen))
                {
                    Owner.Destroy();
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
