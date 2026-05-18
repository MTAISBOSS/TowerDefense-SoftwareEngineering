using EventSystem;

namespace Events
{
    public struct HealthChangedEvent : IEvent
    {
        public float currentHealth;
        public float maxHealth;
    }
}