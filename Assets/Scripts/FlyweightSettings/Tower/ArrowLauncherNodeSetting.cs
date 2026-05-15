using FlyweightEntities.DefenseNodes;
using FlyweightSettings.Projectiles;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    [CreateAssetMenu(menuName = "Flyweight/Tower/Arrow Launcher Setting")]
    public class ArrowLauncherNodeSetting : Flyweight.FlyweightSettings
    {
        public ProjectileSetting projectileSetting;
        public float upgradeRate;
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<ArrowLauncherNode>();
        }
    }
}