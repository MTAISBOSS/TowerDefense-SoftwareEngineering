using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Logger = Utilities.Logger;

namespace WaveSystem
{
    [CreateAssetMenu(menuName = "Wave/Wave Setting")]
    public class SubWaveConfig : ScriptableObject
    {
        public Flyweight.FlyweightSettings setting;
        public float spawnCooldown;
        public int totalNumberOfEntities;
        private float previousWaveLength;
        private void OnValidate()
        {
            if (Math.Abs(previousWaveLength - spawnCooldown * totalNumberOfEntities) < 0.001f)
            {
                return;
            }
            
            previousWaveLength = spawnCooldown * totalNumberOfEntities;
            
            Logger.LogWarning($"Wave length would be {previousWaveLength} seconds");
        }
    }
}