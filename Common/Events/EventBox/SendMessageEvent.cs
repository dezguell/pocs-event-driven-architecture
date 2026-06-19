namespace Common.Events.EventBox
{
    public class SendMessageEvent : DomainEvent
    {
        public string Message { get; }

        public SendMessageEvent(string message)
        {
            Message = message;
        }
    }
}
