using System;
using Cysharp.Threading.Tasks;
using Flyweight;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Flyweight.FlyweightSettings settings;
    private Flyweight.Flyweight currentFlyweight;

    private void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            currentFlyweight  = FlyweightFactory.Spawn(settings);
            Despawn();
        }
    }

    private async void Despawn()
    {
        await UniTask.Delay(2000);
        FlyweightFactory.ReturnToPool(currentFlyweight);
    }
}