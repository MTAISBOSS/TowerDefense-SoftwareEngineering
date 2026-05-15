using FlyweightEntities.Projectiles;
using UnityEngine;

namespace FlyweightSettings.Projectiles
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile/Laser Projectile Setting" ,  fileName = "Laser Projectile Setting")]
    public class LaserProjectileSetting : ProjectileSetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<LaserProjectile>();
        }
    }
}