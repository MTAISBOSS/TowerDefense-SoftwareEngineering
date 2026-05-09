using EventSystem;

namespace Events
{
    public struct GameEndedEvent : IEvent
    {
        public int totalTowers;
        public int remainingMoney;
        public GameState state;
    }

    public enum GameState : byte
    {
        Victory,
        Defeated
    }
}