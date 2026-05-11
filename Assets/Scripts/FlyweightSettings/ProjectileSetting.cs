using FlyweightEntities;
using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Projectile Setting")]
    public class ProjectileSetting : Flyweight.FlyweightSettings
    {
        public float speed;
        public float damage;
        public float despawnTimeInSeconds;

        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Projectile>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}