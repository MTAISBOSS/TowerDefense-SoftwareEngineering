using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    [CreateAssetMenu(menuName = "Flyweight/Tower/Arrow Launcher Setting")]
    public class ArrowLauncherNodeSetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<ArrowLauncherNode>();
        }
    }
}