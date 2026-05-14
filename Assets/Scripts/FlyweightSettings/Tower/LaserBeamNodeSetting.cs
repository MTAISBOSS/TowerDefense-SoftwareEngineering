using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    namespace FlyweightSettings
    {
        [CreateAssetMenu(menuName = "Flyweight/Tower/LaserBeam Setting")]
        public class LaserBeamNodeSetting : Flyweight.FlyweightSettings
        {
            public float damage;
            public override Flyweight.Flyweight Create<T>()
            {
                return base.Create<LaserBeamNode>();
            }
        }
    }
}