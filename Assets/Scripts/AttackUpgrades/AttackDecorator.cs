using AttackStrategies;
using Health;
using UnityEngine;

namespace AttackUpgrades
{
    public abstract class AttackDecorator : IAttackStrategy
    {
        protected readonly IAttackStrategy Wrapped;
        public virtual float Damage { get; }
        public virtual float FireRate { get; }

        protected AttackDecorator(IAttackStrategy wrapped)
        {
            Wrapped = wrapped;
        }
        public virtual void Attack(IDamage target , Vector2 firePoint)
        {
            Wrapped.Attack(target , firePoint);
        }
    }
}
