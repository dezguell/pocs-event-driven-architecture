using System;
using System.Collections.Generic;
using System.Linq;
using Events_POC.Colleagues;
using Events_POC.Events;

namespace Events_POC.Mediator
{
    public class MessageMediator : IMediator
    {
        private readonly Dictionary<Colleague, Event[]> _coleagueContainer;

        public MessageMediator()
        {
            _coleagueContainer = new Dictionary<Colleague, Event[]>();
        }

        public void Subscribe(KeyValuePair<Colleague, Event[]> colleague)
        {
            if (!_coleagueContainer.ContainsKey(colleague.Key))
            {
                _coleagueContainer.Add(colleague.Key, colleague.Value);
            }
            else
            {
                _coleagueContainer[colleague.Key].ToList().AddRange(colleague.Value);
            }
        }

        public void Interact(SendMessageEvent @event)
        {
            var result = string.Empty;
            var eventColleague = @event.GetColleague();
            foreach (var colleagueItem in _coleagueContainer)
            {
                if (colleagueItem.Key != eventColleague)
                    colleagueItem.Key.React(@event);
            }
        }

        public void Interact(SendFriendRequestEvent @event)
        {
            var result = string.Empty;
            var eventColleague = @event.GetColleague();
            var eventColleagueTo = @event.GetColleagueTo();

            if (_coleagueContainer.ContainsKey(eventColleagueTo))
            {
                if (_coleagueContainer[eventColleagueTo].Select(evnt => evnt.GetType().Name)
                    .Contains(@event.GetType().Name))
                {
                    eventColleagueTo.React(@event);
                }
                else
                {
                    Console.WriteLine(" ---- " +
                                      $"{eventColleagueTo.GetType().Name} " +
                                      $"wasn't notified of: {@event.GetType().Name} " +
                                      $"from: {@event.GetColleague().GetType().Name} " +
                                      "because he/she is not subscribed for this event\n");                }
            }

        }

        public void Interact(AnswerFriendRequestEvent @event)
        {
            var eventColleague = @event.GetColleague();
            var eventColleagueFrom = @event.GetColleagueFrom();
            @event.GetColleague().React(@event);
        }

        public IEnumerable<Colleague> GetColleagues()
        {
            return this._coleagueContainer.Keys;
        }
    }
}
