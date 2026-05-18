using System;
using Health;
using UnityEngine;

namespace FlyweightEntities.Projectiles.ProjectileCommands
{
    public class ApplyDamageInRangeCommand : MonoBehaviour, IProjectileCommand
    {
        private float range;
        private float damage;

        public void Execute(
            Transform targetTransform,
            IDamagable target,
            Action onDamageApplied)
        {
            if (Vector2.Distance(transform.position, targetTransform.position) < range)
            {
                if (target != null)
                {
                    target.TakeDamage(damage);
                    onDamageApplied?.Invoke();
                }
            }
        }

        public IProjectileCommand Initialize(params object[] args)
        {
            range = (float)args[0]; // args[0] should be range
            damage = (float)args[1]; // args[1] should be damage
            return this;
        }
    }
}