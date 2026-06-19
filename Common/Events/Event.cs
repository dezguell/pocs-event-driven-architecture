namespace Common.Events
{
    public abstract class Event
    {
        public string PublisherName { get; internal set; }
    }
}