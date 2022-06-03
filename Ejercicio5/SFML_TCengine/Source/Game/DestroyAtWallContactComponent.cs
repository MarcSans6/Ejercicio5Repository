using SFML.Graphics;
using SFML.System;
using System;
using TCEngine;

namespace TCGame
{
    class DestroyAtWallContactComponent : BaseComponent
    {
        public DestroyAtWallContactComponent()
        {

        }

        public override void Update(float _dt)
        {
            base.Update(_dt);

            if (Owner.GetComponent<TransformComponent>().Transform.Position.)
            {

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
