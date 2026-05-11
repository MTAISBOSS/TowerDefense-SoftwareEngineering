using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Events;
using EventSystem;
using Flyweight;
using UnityEngine;
using Logger = Utilities.Logger;

namespace WaveSystem
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;

        private EventBinding<GameStartedEvent> gameStartedEventBinding;
        private EventBinding<StartNewWaveEvent> startNewWaveEventBinding;

        private int waveIndex;

        private void OnEnable()
        {
            gameStartedEventBinding = new EventBinding<GameStartedEvent>(Initialize);
            startNewWaveEventBinding = new EventBinding<StartNewWaveEvent>(StartWave);
            EventBus<GameStartedEvent>.Register(gameStartedEventBinding);
            EventBus<StartNewWaveEvent>.Register(startNewWaveEventBinding);
        }

        private void OnDisable()
        {
            EventBus<GameStartedEvent>.Unregister(gameStartedEventBinding);
            EventBus<StartNewWaveEvent>.Unregister(startNewWaveEventBinding);
        }

        private void Initialize()
        {
            StartWave();
        }

        private async void StartWave()
        {
            var tasks = new List<UniTask>();
            foreach (var wave in waves[waveIndex].waves)
            {
                tasks.Add(SpawnWithCooldown(wave));
            }

            await UniTask.WhenAll(tasks);
            await UniTask.Delay((int)waves[waveIndex].waveCoolDown * 1000);
            ValidateNextWave();
        }

        private void ValidateNextWave()
        {
            waveIndex++;

            if (waveIndex >= waves.Count)
            {
                Logger.Log("All waves ended!");
                EventBus<AllWavesEndedEvent>.Raise(new AllWavesEndedEvent());
            }
            else
            {
                Logger.Log("Starting new wave!");
                EventBus<StartNewWaveEvent>.Raise(new StartNewWaveEvent { waveIndex = waveIndex });
            }
        }

        private async UniTask SpawnWithCooldown(SubWaveConfig subWaveConfig)
        {
            for (int currentSubWaveIndex = 0;
                 currentSubWaveIndex < subWaveConfig.totalNumberOfEntities;
                 currentSubWaveIndex++)
            {
                FlyweightFactory.Spawn(subWaveConfig.setting);
                await UniTask.Delay(1000 * (int)subWaveConfig.spawnCooldown);
            }
        }
    }
}