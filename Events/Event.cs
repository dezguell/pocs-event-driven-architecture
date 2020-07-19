namespace Events_POC
{
    public abstract class Event
    {
        protected Colleague colleague;

        protected Event(Colleague colleague)
        {
            this.colleague = colleague;
        }

        public Colleague GetColleague()
        {
            return this.colleague;
        }

    }
}