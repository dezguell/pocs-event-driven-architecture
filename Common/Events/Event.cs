namespace Common.Events
{
    public abstract class DomainEvent
    {
        public string PublisherName { get; internal set; }
    }
}