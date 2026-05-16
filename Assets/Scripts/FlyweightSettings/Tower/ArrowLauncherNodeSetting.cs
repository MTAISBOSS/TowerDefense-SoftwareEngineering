using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace FlyweightSettings.Tower
{
    [CreateAssetMenu(menuName = "Flyweight/Tower/Arrow Launcher Setting")]
    public class ArrowLauncherNodeSetting : LauncherNodeSetting
    {
        public override Flyweight.Flyweight Create<T>()
        {
            return base.Create<ArrowLauncherNode>();
        }
    }
}