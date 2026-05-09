using System;
using Events;
using EventSystem;
using Unit;
using UnityEngine;

namespace UI
{
    public class BuildNodeUI : MonoBehaviour
    {
        [SerializeField] private OptionsMenuUI optionsMenu;
        
        private BuildNode selectedNode;
        private EventBinding<TowerSelectedEvent> towerSelectedEventBinding;
        private EventBinding<TowerDeselectedEvent> towerDeselectedEventBinding;

        private void OnEnable()
        {
            towerSelectedEventBinding = new EventBinding<TowerSelectedEvent>(SetSelectedNode);
            towerDeselectedEventBinding =
                new EventBinding<TowerDeselectedEvent>(() => optionsMenu.gameObject.SetActive(false));
            EventBus<TowerSelectedEvent>.Register(towerSelectedEventBinding);
            EventBus<TowerDeselectedEvent>.Register(towerDeselectedEventBinding);
        }
        private void OnDisable()
        {
            EventBus<TowerSelectedEvent>.Unregister(towerSelectedEventBinding);
            EventBus<TowerDeselectedEvent>.Unregister(towerDeselectedEventBinding);
        }

        private void SetSelectedNode(TowerSelectedEvent @event)
        {
            selectedNode = @event.node;
            HandleOptionsMenu();
        }

        private void HandleOptionsMenu()
        {
            optionsMenu.gameObject.SetActive(true);
            optionsMenu.Execute(selectedNode.IsPlaced ? OptionMenuType.ModifyNode : OptionMenuType.PlaceNode);
            if (Camera.main != null)
            {
                var screenPoint = Camera.main.WorldToScreenPoint(selectedNode.transform.position);
                optionsMenu.transform.position = screenPoint;
            }
        }
        public BuildNode GetCurrentBuildNode() => selectedNode;

        public void CloseMenu()
        {
            optionsMenu.gameObject.SetActive(false);
        }
    }
}