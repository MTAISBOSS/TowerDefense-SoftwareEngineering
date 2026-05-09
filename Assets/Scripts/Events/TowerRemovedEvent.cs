using EventSystem;
using Unit;

namespace Events
{
    public struct TowerRemovedEvent : IEvent
    {
        public BuildNode node;
    }
}