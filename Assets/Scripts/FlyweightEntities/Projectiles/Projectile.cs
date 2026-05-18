using System;
using Flyweight;
using FlyweightSettings.Projectiles;
using Health;
using UnityEngine;

namespace FlyweightEntities.Projectiles
{
    public class Projectile<T> : Flyweight.Flyweight, IProjectile where T : ProjectileSetting
    {
        protected T Settings => (T)settings;
        private IDamagable damagable;
        private Transform targetTransform;

        protected Transform GetTargetTransform() => targetTransform;
        protected IDamagable GetDamagable() => damagable;
        public void Initialize(IDamagable moveTarget)
        {
            damagable = moveTarget;
            targetTransform = ((MonoBehaviour)damagable).transform;
        }
        protected virtual void Update()
        {
            if (damagable == null)
            {
                Release();
            }
        }
        protected void Release()
        {
            FlyweightFactory.ReturnToPool(this);
        }
    }
}