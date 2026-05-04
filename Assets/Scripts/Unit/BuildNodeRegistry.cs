using System;
using System.Collections.Generic;
using Events; // Assuming BuildNodeEvent is in here
using UnityEngine;

namespace Unit
{
    public class BuildNodeRegistry : MonoBehaviour
    {
        public event Action<Vector2> OnDeactiveMenu;
        public event Action<Vector2> OnActiveMenu;

        private List<BuildNode> _nodes = new List<BuildNode>();
        private BuildNode _currentNode;

        private void OnEnable()
        {
            BuildNodeEvent.OnBuildNodeCreated += RegisterNode;
            BuildNodeEvent.OnBuildNodeDestroyed += UnregisterNode;
        }

        private void OnDisable()
        {
            BuildNodeEvent.OnBuildNodeCreated -= RegisterNode;
            BuildNodeEvent.OnBuildNodeDestroyed -= UnregisterNode;
        }

        private void RegisterNode(BuildNode node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
                node.OnSelected += HandleNodeSelection;
            }
        }

        private void UnregisterNode(BuildNode node)
        {
            if (_nodes.Contains(node))
            {
                node.OnSelected -= HandleNodeSelection;
                _nodes.Remove(node);

                if (_currentNode == node)
                {
                    _currentNode = null;
                    OnDeactiveMenu?.Invoke(node.transform.position);
                }
            }
        }

        private void HandleNodeSelection(BuildNode selectedNode)
        {
            if (_currentNode == selectedNode)
            {
                _currentNode.Deselect();
                _currentNode = null;
                OnDeactiveMenu?.Invoke(selectedNode.transform.position);
                return;
            }
            
            if (_currentNode != null)
            {
                _currentNode.Deselect();
            }
            
            _currentNode = selectedNode;
            _currentNode.Select();
            OnActiveMenu?.Invoke(_currentNode.transform.position);
        }

        public void PlaceNode(DefenseNodeType nodeType)
        {
            if (_currentNode != null)
            {
                _currentNode.PlaceNode(nodeType);

                OnDeactiveMenu?.Invoke(_currentNode.transform.position);
                _currentNode = null;
            }
        }
    }
}
