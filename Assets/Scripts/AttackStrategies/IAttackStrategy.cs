using Health;
using UnityEngine;

namespace AttackStrategies
{
    public interface IAttackStrategy
    {
        float Damage { get; }
        float FireRate { get; }

        void Attack(IDamage target , Vector2 firePoint);
    }
}

