namespace Common.Events
{
    public class SendMessageEvent : Event
    {
        public SendMessageEvent(Service colleague) : base(colleague)
        {
        }
    }
}