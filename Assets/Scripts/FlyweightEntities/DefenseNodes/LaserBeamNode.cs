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
            AttackStrategy = new DamageUpgrade(AttackStrategy, AttackStrategy.Damage * settings.upgradeRate);
            AttackStrategy = new FireRateUpgrade(AttackStrategy, AttackStrategy.FireRate * settings.upgradeRate);
        }
    }
}