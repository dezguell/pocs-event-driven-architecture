namespace Common.Events
{
    public class SendMessageEvent : Event
    {
        public SendMessageEvent(Service.Service colleague) : base(colleague)
        {
        }
    }
}