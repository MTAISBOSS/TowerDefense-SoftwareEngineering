using System;
using Events;
using EventSystem;
using Unit;
using UnityEngine;

namespace UI.Buttons
{
    public class PlaceNodeBtn : MonoBehaviour
    {
        [SerializeField] private DefenseNodeType nodeType;
        private BuildNodeUI buildNodeUI;
        private void Start()
        {
            buildNodeUI = FindAnyObjectByType<BuildNodeUI>();
        }
        
        public void Execute()
        {
            buildNodeUI.GetCurrentBuildNode().PlaceNode(nodeType);
            buildNodeUI.CloseMenu();
        }
    }
}
