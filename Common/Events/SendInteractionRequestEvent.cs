namespace Common.Events
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