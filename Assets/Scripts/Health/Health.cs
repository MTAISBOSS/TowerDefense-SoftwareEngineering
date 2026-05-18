using System;
using UnityEngine;

namespace Health
{
    public class Health : MonoBehaviour, IDamagable
    {
        [Header("Health Settings")]
        [SerializeField] private float maxHealth = 100f; 
        [SerializeField] private float currentHealth = 100f;

        public event Action<float, float> OnHealthChanged;
        public event Action OnDeath;

        public void TakeDamage(float amount)
        {
            if (IsDead()) return;
            currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);
            NotifyHealthChanged();

            if (IsDead())
            {
                Die();
            }
        }

        public void ResetHealth(float value)
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

        private bool IsDead()
        {
            return currentHealth <= 0f;
        }

        private void NotifyHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void Die()
        {
            OnDeath?.Invoke();
        }
    }
}