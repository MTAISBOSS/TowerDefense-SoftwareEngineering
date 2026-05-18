using AttackStrategies;
using AttackUpgrades;
using FlyweightSettings.Tower.FlyweightSettings;

namespace FlyweightEntities.DefenseNodes
{
    public class LaserBeamNode : DefenseNode, IUpgradable
    {
        private new LaserBeamNodeSetting settings => (LaserBeamNodeSetting)base.settings;

        public void Upgrade()
        {
            attackStrategy = new DamageUpgrade(attackStrategy, attackStrategy.Damage * settings.upgradeRate);
            attackStrategy = new FireRateUpgrade(attackStrategy, attackStrategy.FireRate * settings.upgradeRate);
        }
    }
}