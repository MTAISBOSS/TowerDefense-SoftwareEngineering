using FlyweightEntities.DefenseNodes;
using FlyweightSettings.Projectiles;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    namespace FlyweightSettings
    {
        [CreateAssetMenu(menuName = "Flyweight/Tower/FireOrb Launcher Setting")]
        public class FireOrbLauncherNodeSetting : LauncherNodeSetting
        {
            public override Flyweight.Flyweight Create<T>()
            {
                return base.Create<FireOrbLauncherNode>();
            }
        }
    }
}