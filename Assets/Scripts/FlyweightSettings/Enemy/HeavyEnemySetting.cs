using FlyweightEntities.Enemy;
using UnityEngine;

namespace FlyweightSettings.Enemy
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Heavy Enemy Setting")]
    public class HeavyEnemySetting : EnemySetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<HeavyEnemy>();
        }
    }
}