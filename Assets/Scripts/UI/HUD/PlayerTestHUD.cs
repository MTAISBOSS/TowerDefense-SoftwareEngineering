using UnityEngine;
using UnityEngine.InputSystem;
using Health;

public class PlayerTestHUD : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health.Health health;
    [SerializeField] private HealthBarUI healthBarUI;

    [Header("Test Settings")]
    [SerializeField] private float damageAmount = 10f;

    private void Awake()
    {
        if (health == null || healthBarUI == null)
        {
            Debug.LogError("Health or HealthBarUI reference is missing.");
            return;
        }

        health.OnHealthChanged += healthBarUI.UpdateHealthBar;
    }

    private void Start()
    {
        healthBarUI.UpdateHealthBar(
            health.GetHealth(),
            health.GetMaxHealth()
        );
    }

    private void Update()
    {
        if (Keyboard.current == null)
            return;

        // Damage
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            health.TakeDamage(damageAmount);
        }

        // Reset health to max
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            health.ResetHealth(health.GetMaxHealth());
        }
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthChanged -= healthBarUI.UpdateHealthBar;
        }
    }
}