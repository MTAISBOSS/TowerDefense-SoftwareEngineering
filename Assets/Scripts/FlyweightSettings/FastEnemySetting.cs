using FlyweightEntities;
using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Fast Enemy Setting")]
    public class FastEnemySetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public float healthPoint;
        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<FastEnemy>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}