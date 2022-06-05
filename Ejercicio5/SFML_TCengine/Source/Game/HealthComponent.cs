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

        private float m_MaxHealth;

        private float m_CurrentHealth;
        private bool m_Alive = true;

        public HealthComponent(float _maxHealth)
        {
            m_MaxHealth = _maxHealth;
            m_CurrentHealth = m_MaxHealth;
        }
        public float CurrentHealth
        {
            get => m_CurrentHealth;
            set => m_CurrentHealth = value;
        }
        public float MaxHealth
        {
            get => m_MaxHealth;
            set => m_MaxHealth = value;
        }
        public void TakeDmg(float _damage)
        {
            m_CurrentHealth -= _damage;
        }
        
        public override void Update(float _dt)
        {
            base.Update(_dt);

            if (m_CurrentHealth <= 0.0f)
            {
                m_Alive = false;
            }

            Death(!m_Alive);
        }

        public void Death(bool _isDead)
        {

            if (_isDead)
            {
                if (Owner.Name == ("Ally Actor"))
                {

                }
                else
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
            HealthComponent clonedcomponent = new HealthComponent(m_MaxHealth);
            return clonedcomponent;
        }

    }
}
