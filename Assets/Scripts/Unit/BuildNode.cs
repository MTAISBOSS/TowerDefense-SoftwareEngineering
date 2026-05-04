using System;
using DefenseNodes;
using Events;
using UnityEngine;

namespace Unit
{
    public class BuildNode : MonoBehaviour
    {
        [SerializeField] private GameObject selectionVisual;

        public Transform buildPoint;
        public event Action<BuildNode> OnSelected;
        
        private bool _isSelected;
        private IUpgradable _currentUpgradableNode;
        private DefenseNode _currentDefenseNode;

        private void Awake()
        {
            if (selectionVisual != null)
            {
                selectionVisual.SetActive(false);
            }
        }
        
        private void OnEnable()
        {
            BuildNodeEvent.RaiseBuildNodeCreated(this);
        }

        private void OnDisable()
        {
            BuildNodeEvent.RaiseBuildNodeDestroyed(this);
        }

        private void OnMouseDown()
        {
            OnSelected?.Invoke(this);
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
            _currentDefenseNode = DefenseNodeFactory.Instance.CreateNode(nodeType, buildPoint);
            _currentUpgradableNode = _currentDefenseNode.GetComponent<IUpgradable>();
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
            }
        }
    }
}
