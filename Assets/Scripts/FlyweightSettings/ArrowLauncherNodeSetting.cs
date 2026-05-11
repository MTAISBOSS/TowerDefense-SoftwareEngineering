using FlyweightEntities;
using FlyweightEntities.DefenseNodes;
using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Tower/Arrow Launcher Setting")]
    public class ArrowLauncherNodeSetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<ArrowLauncherNode>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}