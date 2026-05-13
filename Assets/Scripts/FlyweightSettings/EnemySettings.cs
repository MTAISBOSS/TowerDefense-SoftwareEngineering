using FlyweightEntities;
using UnityEngine;

namespace FlyweightSettings
{
    [CreateAssetMenu(menuName = "Flyweight/Enemy/Enemy Settings")]
    public class EnemySettings : Flyweight.FlyweightSettings
    {
        [Header("Combat")]
        public float healthPoint = 100f;
        public float damage = 10f;

        [Header("Movement")]
        public float moveSpeed = 5f;

        [Header("Reward")]
        public int goldReward = 10;

        public override Flyweight.Flyweight Create()
        {
            var go = Instantiate(prefab);

            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Enemy>();
            flyweight.settings = this;

            return flyweight;
        }
    }
}