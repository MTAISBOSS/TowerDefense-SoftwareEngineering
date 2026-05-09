using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy Setting")]
    public class EnemySetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public float healthPoint;
        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Entities.Enemy>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}