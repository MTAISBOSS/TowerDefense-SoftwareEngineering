using FlyweightSettings;

namespace Entities
{
    public class Projectile : Flyweight.Flyweight
    {
        private new ProjectileSetting settings => (ProjectileSetting)base.settings;
    }
}