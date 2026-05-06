using UnityEngine;
using UnityEngine.UI;
using TMPro;


    public class ScriptBar : MonoBehaviour
    {
    
         private float fillAmount;
        [SerializeField] private Image content;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private float lerpSpeed;
        public float MaxValue { get; set; }
        public float Value
        {
            set
            {
                valueText.text = value.ToString();
                fillAmount = Map(value, 0, MaxValue,0,1);
            }
        }

        void Update()
        {
            HandleBar();
        }
        private void HandleBar()
        {
            if (fillAmount != content.fillAmount)
            {
                content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
            }
        }
        private float Map (float value,float inMin, float inMax, float outMin, float outMax) 
        {
            return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
  
