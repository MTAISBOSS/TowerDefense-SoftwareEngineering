using System;
using UnityEngine;

namespace Health
{
    public class Health : MonoBehaviour , IDamage
    {
        [Header("Health Settings")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float currentHealth = 100f;

        public event Action<float, float> OnHealthChanged;
        
        public void Initialize()
        {
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            NotifyHealthChanged();
        }

        public void TakeDamage(float amount)
        {
            if (amount <= 0f)
                return;

            currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);

            NotifyHealthChanged();
        }
        public void SetHealth(float value)
        {
            currentHealth = Mathf.Clamp(value, 0f, maxHealth);

            NotifyHealthChanged();
        }

        public void SetMaxHealth(float value)
        {
            maxHealth = Mathf.Max(1f, value);

            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            NotifyHealthChanged();
        }

        public float GetHealth()
        {
            return currentHealth;
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public bool IsDead()
        {
            return currentHealth <= 0f;
        }

        private void NotifyHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}