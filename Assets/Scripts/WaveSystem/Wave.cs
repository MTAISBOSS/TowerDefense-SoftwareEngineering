using System;
using System.Collections;
using System.Collections.Generic;

namespace WaveSystem
{
    [Serializable]
    public class Wave
    {
        public float waveCoolDown;
        public List<SubWaveConfig> waves = new List<SubWaveConfig>();
    }
}