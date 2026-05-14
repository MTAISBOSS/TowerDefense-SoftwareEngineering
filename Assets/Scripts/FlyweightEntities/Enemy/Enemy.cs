using Entity.Movement;
using Flyweight;
using FlyweightSettings.Enemy;
using UnityEngine;

namespace FlyweightEntities.Enemy
{
    public class Enemy<T> : Flyweight.Flyweight, IMovable
        where T : EnemySetting
    {
        private new T settings => (T)base.settings;
        private EntityBatchMovement movementRegistry;
        private Health.Health health;

        private void OnEnable()
        {
            if (gameObject.TryGetComponent(out health))
            {
                health.ResetHealth(settings.healthPoint);
                health.OnDeath += OnDeath;
            }

            movementRegistry = EntityBatchMovement.instance;
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

        public virtual void OnDeath()
        {
            var effect = Instantiate(settings.deathEffect, transform.position, Quaternion.identity);
            Destroy(effect , settings.deathEffectDuration);
            Stop();
        }
    }
}