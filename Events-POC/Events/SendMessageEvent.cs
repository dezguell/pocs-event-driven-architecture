namespace Events_POC
{
    public class SendMessageEvent : Event
    {
        public SendMessageEvent(Colleague colleague) : base(colleague)
        {
        }
    }
}