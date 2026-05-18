using FlyweightEntities.Enemy;
using UnityEngine;

namespace FlyweightSettings.Enemy
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Fast Enemy Setting")]
    public class FastEnemySetting : EnemySetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<FastEnemy>();
        }
    }
}