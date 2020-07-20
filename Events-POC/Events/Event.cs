using Events_POC.Services;

namespace Events_POC.Events
{
    public abstract class Event
    {
        protected Service service;

        protected Event(Service service)
        {
            this.service = service;
        }

        public Service GetService()
        {
            return this.service;
        }
    }
}