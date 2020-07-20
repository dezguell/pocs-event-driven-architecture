using Events_POC.Services;

namespace Events_POC.Events
{
    public class AnswerInteractionRequestEvent : Event
    {
        private Service serviceFrom;
        private bool answer;

        public AnswerInteractionRequestEvent(Service service, Service serviceFrom, bool answer) : base(service)
        {
            this.serviceFrom = serviceFrom;
            this.answer = answer;
        }

        public Service GetColleagueFrom()
        {
            return serviceFrom;
        }

        public bool GetAnswer()
        {
            return this.answer;
        }
    }
}