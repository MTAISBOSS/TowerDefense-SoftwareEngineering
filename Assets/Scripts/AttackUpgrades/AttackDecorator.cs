using AttackStrategies;
using Unit;

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
        public virtual void Attack(Enemy target)
        {
            Wrapped.Attack(target);
        }
    }
}