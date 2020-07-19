using System;
using System.Collections.Generic;
using System.Linq;
using Events_POC.Colleagues;
using Events_POC.Events;

namespace Events_POC.Mediator
{
    public class MessageMediator : IMediator
    {
        private readonly Dictionary<Colleague, Event[]> _observersContainer;

        public MessageMediator()
        {
            _observersContainer = new Dictionary<Colleague, Event[]>();
        }

        public void Subscribe(KeyValuePair<Colleague, Event[]> colleague)
        {
            if (!_observersContainer.ContainsKey(colleague.Key))
            {
                _observersContainer.Add(colleague.Key, colleague.Value);
            }
            else
            {
                _observersContainer[colleague.Key].ToList().AddRange(colleague.Value);
            }
        }

        public void Interact(SendMessageEvent @event)
        {
            var result = string.Empty;
            var eventColleague = @event.GetColleague();
            foreach (var colleagueItem in _observersContainer)
            {
                if (colleagueItem.Key != eventColleague)
                    result += " ---- " +
                              $"{colleagueItem.Key.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {eventColleague.GetType().Name} " +
                              $"with content: {eventColleague.GetMessage()}\n";
            }

            Console.WriteLine(result);
        }

        public void Interact(SendFriendRequestEvent @event)
        {
            var result = string.Empty;
            var eventColleague = @event.GetColleague();
            var eventColleagueTo = @event.GetColleagueTo();

            if (_observersContainer.ContainsKey(eventColleagueTo))
            {
                if (_observersContainer[eventColleagueTo].Select(event1 => event1.GetType().Name)
                    .Contains(@event.GetType().Name))
                {
                    Console.WriteLine(" ---- " +
                              $"{eventColleagueTo.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {@event.GetColleagueTo().GetType().Name}");

                    @event.GetColleagueTo().AnswerFriendRequestFrom(eventColleague);
                }
                else
                {
                    Console.WriteLine(" ---- " +
                                      $"{eventColleagueTo.GetType().Name} " +
                                      $"wasn't notified of: {@event.GetType().Name} " +
                                      $"from: {@event.GetColleague().GetType().Name} " +
                                      "because he/she is not subscribed for this event\n");
                }
            }

        }

        public void Interact(AnswerFriendRequest @event)
        {
            var eventColleague = @event.GetColleague();
            var eventColleagueFrom = @event.GetColleagueFrom();
            Console.WriteLine(" ---- " +
                              $"{eventColleague.GetType().Name} " +
                              $"answered with: '{@event.GetAnswer()}' " +
                              $"to the: SendFriendRequestEvent" +
                              $" from {eventColleagueFrom.GetType().Name}\n");
        }

        public IEnumerable<Colleague> GetColleagues()
        {
            return this._observersContainer.Keys;
        }
    }
}
