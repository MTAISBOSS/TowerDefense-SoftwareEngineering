using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Normal Enemy Setting")]
    public class NormalEnemySetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public float healthPoint;
        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Entities.NormalEnemy>();
            flyweight.settings = this;
            return flyweight;
        }
    }
}