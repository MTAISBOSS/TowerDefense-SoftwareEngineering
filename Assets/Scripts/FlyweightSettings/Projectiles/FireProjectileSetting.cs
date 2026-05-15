using FlyweightEntities.Projectiles;
using UnityEngine;

namespace FlyweightSettings.Projectiles
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile/Fire Projectile Setting" , fileName = "Fire Projectile Setting")]
    public class FireProjectileSetting : ProjectileSetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<FireProjectile>();
        }
    }
}