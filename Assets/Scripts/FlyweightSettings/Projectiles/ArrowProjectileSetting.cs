using FlyweightEntities.Projectiles;
using UnityEngine;

namespace FlyweightSettings.Projectiles
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile/Arrow Projectile Setting" , fileName = "Arrow Projectile Setting")]
    public class ArrowProjectileSetting : ProjectileSetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<ArrowProjectile>();
        }
    }
}