using AttackStrategies;
using AttackUpgrades;
using FlyweightSettings.Tower;

namespace FlyweightEntities.DefenseNodes
{
    public class ArrowLauncherNode : DefenseNode,IUpgradable
    {
        private new ArrowLauncherNodeSetting settings => (ArrowLauncherNodeSetting)base.settings;
        
        private void Awake()
        {
            AttackStrategy = new ProjectileAttackStrategy(settings.projectileSetting);
        }

        public void Upgrade()
        {
            AttackStrategy = new DamageUpgrade(AttackStrategy, AttackStrategy.Damage * settings.upgradeRate);
        }
        
    }
}