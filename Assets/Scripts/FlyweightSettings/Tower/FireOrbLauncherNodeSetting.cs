using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    namespace FlyweightSettings
    {
        [CreateAssetMenu(menuName = "Flyweight/Tower/FireOrb Launcher Setting")]
        public class FireOrbLauncherNodeSetting : Flyweight.FlyweightSettings
        {
            public float damage;
            public override Flyweight.Flyweight Create<T>()
            {
                return base.Create<FireOrbLauncherNode>();
            }
        }
    }
}