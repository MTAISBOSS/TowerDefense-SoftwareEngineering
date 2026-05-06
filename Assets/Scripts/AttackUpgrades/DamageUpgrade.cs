using AttackStrategies;

namespace AttackUpgrades
{
    public class DamageUpgrade : AttackDecorator
    {
        private readonly float _extraDamage;

        public DamageUpgrade(IAttackStrategy wrapped, float extraDamage) : base(wrapped)
        {
            _extraDamage = extraDamage;
        }

        public override float Damage => Wrapped.Damage + _extraDamage;
    }
}