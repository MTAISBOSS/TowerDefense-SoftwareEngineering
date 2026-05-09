using EventSystem;
using Unit;

namespace Events
{
    public struct TowerPlacedEvent : IEvent
    {
        public DefenseNodeType node;
    }
}