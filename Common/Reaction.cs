using Common.Events;

namespace Common
{
    public abstract class Reaction
    {
        protected Service service;

        protected Reaction(Service service)
        {
            this.service = service;
        }

        public abstract void ReactTo(Event @event);
    }
}