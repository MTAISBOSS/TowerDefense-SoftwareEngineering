using UnityEngine;

namespace UI.Buttons
{
    public class UpgradeNodeBtn : MonoBehaviour
    {
        private BuildNodeUI buildNodeUI;
        private void Start()
        {
            buildNodeUI = FindAnyObjectByType<BuildNodeUI>();
        }
        
        public void Execute()
        {
            buildNodeUI.GetCurrentBuildNode().UpgradeNode();
            buildNodeUI.CloseMenu();
        }
    }
}