using AttackStrategies;

namespace AttackUpgrades
{
    public class FireRateUpgrade : AttackDecorator
    {
        private readonly float extraFireRate;

        public FireRateUpgrade(IAttackStrategy wrapped, float extraFireRate) : base(wrapped)
        {
            this.extraFireRate = extraFireRate;
        }

        public override float FireRate => Wrapped.FireRate + this.extraFireRate;
    }
}