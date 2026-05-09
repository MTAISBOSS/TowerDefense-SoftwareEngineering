using EventSystem;
using Unit;

namespace Events
{
    public struct TowerSelectedEvent : IEvent
    {
        public BuildNode node;
    }
}