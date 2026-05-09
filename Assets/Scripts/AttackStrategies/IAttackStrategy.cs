using Entity;
using Unit;
using UnityEngine;
using Enemy = Unit.Enemy;

namespace AttackStrategies
{
    public interface IAttackStrategy
    {
        float Damage { get; }
        float FireRate { get; }

        void Attack(Enemy target);
    }
}

