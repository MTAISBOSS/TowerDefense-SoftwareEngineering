using System;
using EventSystem;

namespace Events
{
    public struct StartNewWaveEvent : IEvent
    {
        public int waveIndex;
    }
}