using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Health
{
    public class HealthBarUI : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI healthText;

        [Header("Animation Settings")]
        [SerializeField] private float animationDuration = 0.25f;

        private Tween fillTween;

        public void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            float targetFillAmount = currentHealth / maxHealth;

            fillTween?.Kill();

            fillTween = fillImage.DOFillAmount(targetFillAmount, animationDuration);

            healthText.text = $"{currentHealth:0}";
        }

        private void OnDestroy()
        {
            fillTween?.Kill();
        }
    }
}