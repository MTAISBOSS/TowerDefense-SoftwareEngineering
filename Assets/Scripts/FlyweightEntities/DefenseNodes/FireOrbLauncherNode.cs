using AttackUpgrades;
using Flyweight;
using FlyweightSettings.Tower.FlyweightSettings;
using Health;

namespace FlyweightEntities.DefenseNodes
{
    public class FireOrbLauncherNode : DefenseNode, IUpgradable
    {
        private FireRateUpgrade _fireRateUpgrade;
        private new FireOrbLauncherNodeSetting settings => (FireOrbLauncherNodeSetting)base.settings;

        public void Upgrade()
        {
            _fireRateUpgrade = new FireRateUpgrade(_fireRateUpgrade, _fireRateUpgrade.FireRate);
        }
        
        private void Update()
        {
            var target = FindTarget();
            if (target == null) return;
            coolDownTimer += UnityEngine.Time.deltaTime;
            if (coolDownTimer >= 1f)
            {
                FlyweightFactory.Spawn(settings);
                _fireRateUpgrade.Attack(target);
                coolDownTimer = 0f;
            }
        }

        private IDamage FindTarget()
        {
            return null;
        }
    }
}