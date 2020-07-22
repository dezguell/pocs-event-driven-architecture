namespace Common.Events
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