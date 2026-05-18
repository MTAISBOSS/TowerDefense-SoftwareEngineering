using FlyweightEntities.Enemy;
using UnityEngine;

namespace FlyweightSettings.Enemy
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Normal Enemy Setting")]
    public class NormalEnemySetting : EnemySetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<NormalEnemy>();
        }
    }
}