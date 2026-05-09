using UnityEngine;

namespace UI.Buttons
{
    public class RemoveNodeBtn : MonoBehaviour
    {
        private BuildNodeUI buildNodeUI;
        private void Start()
        {
            buildNodeUI = FindAnyObjectByType<BuildNodeUI>();
        }
        
        public void Execute()
        {
            buildNodeUI.GetCurrentBuildNode().RemoveNode();
            buildNodeUI.CloseMenu();
        }
    }
}