using System.Collections.Generic;
using Entity.Movement;
using Flyweight;
using UnityEngine;

namespace Entity
{
    public class MovingEntitySpawner : MonoBehaviour
    {
        [SerializeField] private int spawnAmount;
        [SerializeField] private Flyweight.FlyweightSettings settings;

        private readonly List<Flyweight.Flyweight> flyweights = new();
        private EntityBatchMovement _entityBatchMovement;

        private void Awake()
        {
            _entityBatchMovement = GetComponent<EntityBatchMovement>();
        }

        private void Start()
        {
            Create();
        }

        private void Create()
        {
            var spawnedTransforms = new List<Transform>();
            for (int i = 0; i < spawnAmount; i++)
            {
                var currentFlyweight = FlyweightFactory.Spawn(settings);
                currentFlyweight.transform.position = this.transform.position;
                spawnedTransforms.Add(currentFlyweight.transform);
                flyweights.Add(currentFlyweight);
            }

            _entityBatchMovement.Setup(spawnedTransforms, flyweights);
        }
    }
}