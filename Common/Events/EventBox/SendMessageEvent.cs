namespace Common.Events.EventBox
{
    public class SendMessageEvent : Event
    {
        public string Message { get; }

        public SendMessageEvent(string message)
        {
            Message = message;
        }
    }
}