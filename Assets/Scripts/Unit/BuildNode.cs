using System;
using Events;
using EventSystem;
using FlyweightEntities.DefenseNodes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Unit
{
    public class BuildNode : MonoBehaviour
    {
        [SerializeField] private GameObject selectionVisual;

        public Transform buildPoint;
        public UnityEvent OnPlaced;
        public UnityEvent OnRemoved;
        private bool _isSelected;
        private IUpgradable _currentUpgradableNode;
        private DefenseNode _currentDefenseNode;

        private EventBinding<TowerRemovedEvent> towerRemovedEventBinding;
        private EventBinding<TowerSelectedEvent> towerSelectedEventBinding;

        public bool IsPlaced { get; private set; }
        private void Awake()
        {
            if (selectionVisual != null)
            {
                selectionVisual.SetActive(false);
            }
        }

        private void Update()
        {
            HandleSelection();
        }

        private void HandleSelection()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                if (Camera.main != null)
                {
                    Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        EventBus<TowerSelectedEvent>.Raise(new TowerSelectedEvent() { node = this });
                    }
                }
            }
        }

        public void Select()
        {
            _isSelected = true;
            if (selectionVisual != null)
            {
                selectionVisual.SetActive(true);
            }
        }

        public void Deselect()
        {
            _isSelected = false;
            if (selectionVisual != null)
            {
                selectionVisual.SetActive(false);
            }
        }

        public void PlaceNode(DefenseNodeType nodeType)
        {
            if (_currentDefenseNode)
            {
                return;
            }

            EventBus<TowerPlacedEvent>.Raise(new TowerPlacedEvent() { node = nodeType });
            _currentDefenseNode = DefenseNodeFactory.Instance.CreateNode(nodeType, buildPoint);
            _currentUpgradableNode = _currentDefenseNode.GetComponent<IUpgradable>();
            IsPlaced = true;
            OnPlaced?.Invoke();
        }

        public void UpgradeNode()
        {
            if (_currentUpgradableNode != null)
            {
                _currentUpgradableNode.Upgrade();
            }
        }

        public void RemoveNode()
        {
            if (_currentDefenseNode != null)
            {
                Destroy(_currentDefenseNode.gameObject);
                _currentDefenseNode = null;
                _currentUpgradableNode = null;
                EventBus<TowerRemovedEvent>.Raise(new TowerRemovedEvent() { node = this});
                IsPlaced = false;
                OnRemoved?.Invoke();
            }
        }
    }
}