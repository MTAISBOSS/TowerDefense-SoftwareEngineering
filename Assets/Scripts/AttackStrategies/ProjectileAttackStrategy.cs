using System;
using Flyweight;
using FlyweightEntities;
using FlyweightEntities.Projectiles;
using FlyweightSettings;
using FlyweightSettings.Projectiles;
using Health;
using UnityEngine;
using Logger = Utilities.Logger;

namespace AttackStrategies
{
    public class ProjectileAttackStrategy : IAttackStrategy
    {
        public float Damage { get; private set; }
        public float FireRate { get; private set; } = 1f;
        private readonly ProjectileSetting _projectileSetting;
        private Type _projectileType;

        public ProjectileAttackStrategy(ProjectileSetting projectileSetting)
        {
            _projectileSetting = projectileSetting;
            Damage = _projectileSetting.damage;
        }
        
        public void Attack(IDamagable target , Vector2 firePoint)
        {
            var flyweight = FlyweightFactory.Spawn(_projectileSetting);
            var projectile = flyweight.GetComponent<IProjectile>();
            if (projectile == null)
            {
                Logger.LogWarning("Projectile setting not found");
                return;
            }
            flyweight.transform.position = firePoint;
            projectile.Initialize(target);
        }
    }
}
