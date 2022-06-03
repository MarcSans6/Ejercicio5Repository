using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using System;
using TCEngine;

namespace TCGame
{
    public class BounceComponent: BaseComponent
    {
        public BounceComponent()
        {
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
