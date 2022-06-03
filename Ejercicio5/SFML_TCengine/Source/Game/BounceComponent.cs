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
        private float m_Speed = 100.0f;
        private Vector2f mouse_Forward;
        private Vector2f refactor_Forward;

        public float Speed
        {
            get => m_Speed;
            set => m_Speed = value;
        }

        public Vector2f MouseDirection
        {
            get => mouse_Forward;
            set => mouse_Forward = value;
        }

        public Vector2f RefractDirection
        {
            get => refactor_Forward;
            set => refactor_Forward = value;
        }

        public BounceComponent()
        {
            
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);


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
