using Events_POC.Services;

namespace Events_POC.Events
{
    public class SendMessageEvent : Event
    {
        public SendMessageEvent(Service colleague) : base(colleague)
        {
        }
    }
}