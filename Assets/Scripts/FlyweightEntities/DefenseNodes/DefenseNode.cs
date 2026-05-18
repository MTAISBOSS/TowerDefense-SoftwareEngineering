using AttackStrategies;
using FlyweightSettings.Tower;
using Health;
using UnityEngine;

namespace FlyweightEntities.DefenseNodes
{
    public abstract class DefenseNode : Flyweight.Flyweight
    {
        public float coolDownTimer = 0f;
        protected IAttackStrategy attackStrategy;

        private void Awake()
        {
            var launcherNodeSetting = (LauncherNodeSetting)settings;
            attackStrategy = new ProjectileAttackStrategy(launcherNodeSetting.projectileSetting);
        }

        private void Update()
        {
            if (attackStrategy == null) return;
            
            var target = ClosestDamagableFinder.GetClosestDamagable(transform);
            
            if (target != null)
                HandleCooldown(target);
        }

        private void HandleCooldown(IDamagable target)
        {
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= 1f / attackStrategy.FireRate)
            {
                HandleOnCooldownStart(target);
                coolDownTimer = 0f;
            }
        }

        private void HandleOnCooldownStart(IDamagable target)
        {
            attackStrategy.Attack(target, transform.position);
        }
    }
}