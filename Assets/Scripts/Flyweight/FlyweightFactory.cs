using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Flyweight
{
    public class FlyweightFactory : MonoBehaviour
    {
        [SerializeField] private bool collectionCheck;
        [SerializeField] private int defaultCapacity;
        [SerializeField] private int maxPoolSize;


        private static FlyweightFactory _instance;
        private readonly Dictionary<FlyweightType, IObjectPool<Flyweight>> pools = new();

        private void Awake()
        {
            _instance = this;
        }

        public static Flyweight Spawn(FlyweightSettings settings) => _instance.GetPoolFor(settings).Get();

        public static void ReturnToPool(Flyweight flyweight) =>
            _instance.GetPoolFor(flyweight.settings)?.Release(flyweight);


        IObjectPool<Flyweight> GetPoolFor(FlyweightSettings settings)
        {
            if (pools.TryGetValue(settings.type, out var pool))
            {
                return pool;
            }

            pool = new ObjectPool<Flyweight>(
                settings.Create,
                settings.OnGet,
                settings.OnRelease,
                settings.OnDestroyPoolObject,
                collectionCheck,
                defaultCapacity,
                maxPoolSize
            );
            pools.Add(settings.type, pool);
            return pool;
        }
    }
}