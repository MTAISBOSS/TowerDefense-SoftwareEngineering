using AttackStrategies;
using AttackUpgrades;
using FlyweightSettings.Tower.FlyweightSettings;

namespace FlyweightEntities.DefenseNodes
{
    public class FireOrbLauncherNode : DefenseNode, IUpgradable
    {
        private new FireOrbLauncherNodeSetting settings => (FireOrbLauncherNodeSetting)base.settings;

        public void Upgrade()
        {
            AttackStrategy = new FireRateUpgrade(AttackStrategy, AttackStrategy.FireRate * settings.upgradeRate);
        }
    }
}