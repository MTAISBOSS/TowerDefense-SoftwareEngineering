using EventSystem;

namespace Events
{
    public struct GameResultEvent : IEvent
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