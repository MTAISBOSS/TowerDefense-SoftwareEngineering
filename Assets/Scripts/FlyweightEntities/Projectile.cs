using FlyweightSettings;

namespace FlyweightEntities
{
    public class Projectile : Flyweight.Flyweight
    {
        private new ProjectileSetting settings => (ProjectileSetting)base.settings;
    }
}