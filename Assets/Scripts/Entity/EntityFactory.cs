using System.Collections.Generic;
using Entity.Movement;
using UnityEngine;

namespace Entity
{
    public class EntityFactory : MonoBehaviour
    {
        [SerializeField] private int count;
        [SerializeField] private GameObject entityPrefab;

        private readonly List<Transform> _entityTransforms = new();
        private EntityBatchMovement _batchMovement;

        private void Awake()
        {
            _batchMovement = GetComponent<EntityBatchMovement>();
        }

        private void Start()
        {
            Create();
            _batchMovement.Setup(_entityTransforms);
        }

        private void Create()
        {
            for (int i = 0; i < count; i++)
            {
                var entity = Instantiate(entityPrefab, transform.position, Quaternion.identity);
                entity.transform.SetParent(transform);
                _entityTransforms.Add(entity.transform);
            }
        }
    }
}