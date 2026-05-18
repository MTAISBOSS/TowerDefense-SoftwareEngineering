using UnityEngine;

namespace FlyweightSettings.Enemy
{
    public class EnemySetting : Flyweight.FlyweightSettings
    {
        public float damage;
        public float healthPoint;
        public GameObject deathEffect;
        public float deathEffectDuration;
    }
}