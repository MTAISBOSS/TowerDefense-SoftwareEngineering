using System.Collections.Generic;
using FlyweightEntities.Projectiles.ProjectileCommands;

namespace FlyweightSettings.Projectiles
{
    public class ProjectileSetting : Flyweight.FlyweightSettings
    {
        public float speed;
        public float damage;
        public float despawnTimeInSeconds = 5f;
        public float despawnRange = 0.1f;
    }
}