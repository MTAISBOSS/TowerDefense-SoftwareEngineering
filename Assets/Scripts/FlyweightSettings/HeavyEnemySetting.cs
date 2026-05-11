using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Heavy Enemy Setting")]
    public class HeavyEnemySetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public float healthPoint;
        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Entities.HeavyEnemy>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}