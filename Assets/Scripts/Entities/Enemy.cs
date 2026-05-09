using FlyweightSettings;

namespace Entities
{
    public class Enemy : Flyweight.Flyweight
    {
        private new EnemySetting settings => (EnemySetting)base.settings;
    }
}