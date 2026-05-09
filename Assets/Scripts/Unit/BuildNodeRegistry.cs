using System;
using System.Collections.Generic;
using Events;
using EventSystem;
using UnityEngine;

namespace Unit
{
    public class BuildNodeRegistry : MonoBehaviour
    {
        private List<BuildNode> _nodes = new List<BuildNode>();
        private BuildNode _currentNode;

        private void RegisterNode(BuildNode node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
            }
        }

        private void UnregisterNode(BuildNode node)
        {
            if (_nodes.Contains(node))
            {
                _nodes.Remove(node);

                if (_currentNode == node)
                {
                    _currentNode = null;
                    EventBus<TowerDeselectedEvent>.Raise(new TowerDeselectedEvent());
                }
            }
        }

        private void HandleNodeSelection(BuildNode selectedNode)
        {
            if (_currentNode == selectedNode)
            {
                _currentNode.Deselect();
                _currentNode = null;
                EventBus<TowerDeselectedEvent>.Raise(new TowerDeselectedEvent());

                return;
            }
            
            if (_currentNode != null)
            {
                _currentNode.Deselect();
            }
            
            _currentNode = selectedNode;
            _currentNode.Select();
            EventBus<TowerSelectedEvent>.Raise(new TowerSelectedEvent(){node = selectedNode});

        }

        public void PlaceNode(DefenseNodeType nodeType)
        {
            if (_currentNode != null)
            {
                _currentNode.PlaceNode(nodeType);

                EventBus<TowerDeselectedEvent>.Raise(new TowerDeselectedEvent());

                _currentNode = null;
            }
        }
    }
}
