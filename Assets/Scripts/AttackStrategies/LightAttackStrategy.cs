using Unit;
using UnityEngine;

namespace AttackStrategies
{
    public class LightAttackStrategy : IAttackStrategy
    {
        public GameObject projectile;

        public float Damage { get; private set; } = 5;
        public float FireRate { get; private set; } = 0.1f;
        
        public void Attack(Enemy target)
        {
            target.TakeDamage(Damage);
        }
    }
}