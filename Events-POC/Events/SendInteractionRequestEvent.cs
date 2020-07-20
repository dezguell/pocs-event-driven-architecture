using Events_POC.Services;

namespace Events_POC.Events
{
    public class SendInteractionRequestEvent : Event
    {
        private Service serviceTo;
        public SendInteractionRequestEvent(Service service, Service colleagueTo) : base(service)
        {
            this.serviceTo = colleagueTo;
        }

        public Service GetColleagueTo()
        {
            return serviceTo;
        }
    }
}