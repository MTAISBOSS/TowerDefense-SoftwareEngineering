using Flyweight;
using FlyweightSettings.Projectiles;
using Health;
using UnityEngine;

namespace FlyweightEntities.Projectiles
{
    public class Projectile<T> : Flyweight.Flyweight , IProjectile where T : ProjectileSetting
    {
        private new T settings => (T)base.settings;
        private IDamage target;
        private Transform targetTransform;

        public void Initialize(IDamage moveTarget)
        {
            target = moveTarget;
            targetTransform = ((MonoBehaviour)target).transform;
        }

        private void Update()
        {
            if (target == null)
            {
                Release();
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position,
                targetTransform.position, settings.speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetTransform.position) < 0.1)
            {
                target.TakeDamage(settings.damage);
                Release();
            }
        }

        private void Release()
        {
            FlyweightFactory.ReturnToPool(this);
        }
    }
}