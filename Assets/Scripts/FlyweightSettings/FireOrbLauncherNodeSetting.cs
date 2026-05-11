namespace FlyweightSettings
{
    using FlyweightEntities;
    using FlyweightEntities.DefenseNodes;
    using UnityEngine;

    namespace FlyweightSettings
    {
        [CreateAssetMenu(menuName = "Flyweight/Tower/FireOrb Launcher Setting")]
        public class FireOrbLauncherNodeSetting : Flyweight.FlyweightSettings
        {
            public float damage;
            public override Flyweight.Flyweight Create()
            {
                var go = Instantiate(prefab);
                go.SetActive(false);
                go.name = prefab.name;

                var flyweight = go.AddComponent<FireOrbLauncherNode>();
                flyweight.settings = this;
                return flyweight;
            }
        }
    }
}