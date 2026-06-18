using Common.Events;

namespace Common.Reaction
{
    public abstract class Reaction
    {
        protected Service.Service service;

        protected Reaction(Service.Service service)
        {
            this.service = service;
        }

        public abstract void ReactTo(Event @event);
    }
}