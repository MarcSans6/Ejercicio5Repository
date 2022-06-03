using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics;
using TCEngine;

namespace TCGame
{
    public class HealthComponent:BaseComponent
    {

        public const float MAX_HEALTH;

        public float m_CurrentHealth;
        private bool m_Alive = true;

        public HealthComponent()
        {
            m_CurrentHealth = MAX_HEALTH;
        }
        public float CurrentHealth
        {
            get => m_CurrentHealth;
            set => m_CurrentHealth = value;
        }
        public void TakeDmg(float dmg)
        {
            m_CurrentHealth -= dmg;

        }
        
        public override void Update(float _dt)
        {
            float life = m_CurrentHealth;
            
            if (life <= 0)
            {
                m_Alive = false;
                Death();
            }
        }

        public void Death()
        {
            Owner.Destroy();
        }
        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

    }
}
