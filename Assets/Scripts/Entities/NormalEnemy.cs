using System;
using Entity.Movement;
using Flyweight;
using FlyweightSettings;
using UnityEngine;

namespace Entities
{
    public class NormalEnemy : Flyweight.Flyweight, IMovable
    {
        private new NormalEnemySetting settings => (NormalEnemySetting)base.settings;
        private EntityBatchMovement movementRegistry;

        private void OnEnable()
        {
            if (gameObject.TryGetComponent(out Health.Health health))
            {
                health.ResetHealth(settings.healthPoint);
            }

            movementRegistry = EntityBatchMovement.Instance;
            movementRegistry.Register(this);
        }

        private void OnDisable()
        {
            movementRegistry.UnRegister(this);
        }

        public void Stop()
        {
            FlyweightFactory.ReturnToPool(this);
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}