using System;
using FlyweightEntities.Projectiles.ProjectileCommands;
using FlyweightSettings.Projectiles;
using UnityEngine;

namespace FlyweightEntities.Projectiles
{
    public class ArrowProjectile : Projectile<ArrowProjectileSetting>
    {
        private ApplyDamageInRangeCommand damageCommand;
        private MoveTowardsTargetCommand moveCommand;
        private RotateTowardsTargetCommand rotateCommand;

        private void Start()
        {
            damageCommand = (ApplyDamageInRangeCommand)gameObject.AddComponent<ApplyDamageInRangeCommand>().Initialize(Settings.despawnRange,Settings.damage);
            moveCommand = (MoveTowardsTargetCommand)gameObject.AddComponent<MoveTowardsTargetCommand>().Initialize(Settings.speed);
            rotateCommand = gameObject.AddComponent<RotateTowardsTargetCommand>();
        }

        protected override void Update()
        {
            base.Update();
            moveCommand.Execute(GetTargetTransform());
            damageCommand.Execute(GetTargetTransform(), GetDamagable(), Release);
            rotateCommand.Execute(GetTargetTransform());
        }
    }
}