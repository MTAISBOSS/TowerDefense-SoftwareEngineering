using Unit;
using UnityEngine;

namespace AttackStrategies
{
    public interface IAttackStrategy
    {
        float Damage { get; }
        float FireRate { get; }

        void Attack(Enemy target);
    }
}

