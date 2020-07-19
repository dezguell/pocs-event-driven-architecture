using Events_POC.Colleagues;

namespace Events_POC.Events
{
    public class SendMessageEvent : Event
    {
        public SendMessageEvent(Colleague colleague) : base(colleague)
        {
        }
    }
}