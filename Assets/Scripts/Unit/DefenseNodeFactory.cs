using System;
using System.Linq;
using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace Unit
{
    public class DefenseNodeFactory : MonoBehaviour
    {
        public static DefenseNodeFactory Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [SerializeField] private NodeRelation[] nodeRelations;
        public DefenseNode CreateNode(DefenseNodeType nodeType,Transform parent)
        {
            NodeRelation nodeRelation = nodeRelations.FirstOrDefault(o => o.nodeType == nodeType);
            var node =Instantiate(nodeRelation.nodePrefab, parent, true);
            return node;
        }
    }

    [Serializable]
    public struct NodeRelation
    {
        public DefenseNodeType nodeType;
        public DefenseNode nodePrefab;
    }
}