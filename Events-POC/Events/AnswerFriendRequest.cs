using Events_POC.Colleagues;

namespace Events_POC.Events
{
    public class AnswerFriendRequest : Event
    {
        private Colleague colleagueFrom;
        private bool answer;

        public AnswerFriendRequest(Colleague ema, Colleague colleagueFrom, bool answer) : base(ema)
        {
            this.colleagueFrom = colleagueFrom;
            this.answer = answer;
        }

        public Colleague GetColleagueFrom()
        {
            return colleagueFrom;
        }

        public bool GetAnswer()
        {
            return this.answer;
        }
    }
}