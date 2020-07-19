using Events_POC.Colleagues;

namespace Events_POC.Events
{
    public class SendFriendRequestEvent : Event
    {
        private Colleague colleagueTo;
        public SendFriendRequestEvent(Colleague colleague, Colleague colleagueTo) : base(colleague)
        {
            this.colleagueTo = colleagueTo;
        }

        public Colleague GetColleagueTo()
        {
            return colleagueTo;
        }
    }
}