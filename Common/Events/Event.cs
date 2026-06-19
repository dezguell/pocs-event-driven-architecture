namespace Common.Events
{
    public abstract class DomainEvent
    {
        public string EventName { get; internal set; }
        public string PublisherName { get; internal set; }
    }
}
