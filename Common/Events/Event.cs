namespace Common.Events
{
    public abstract class Event
    {
        protected Service.Service service;

        protected Event(Service.Service service)
        {
            this.service = service;
        }

        public Service.Service GetService()
        {
            return this.service;
        }
    }
}