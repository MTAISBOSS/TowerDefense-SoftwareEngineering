using Entity.Movement;
using Flyweight;
using FlyweightSettings;
using UnityEngine;

namespace FlyweightEntities
{
    public class Enemy : Flyweight.Flyweight, IMovable
    {
        private EnemySettings EnemyData => base.settings as EnemySettings;

        private EntityBatchMovement movementRegistry;

        private void OnEnable()
        {
            if (gameObject.TryGetComponent(out Health.Health health))
            {
                health.ResetHealth(EnemyData.healthPoint);
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

        public float GetMoveSpeed()
        {
            return EnemyData.moveSpeed;
        }

        public float GetDamage()
        {
            return EnemyData.damage;
        }

        public int GetReward()
        {
            return EnemyData.goldReward;
        }
    }
}