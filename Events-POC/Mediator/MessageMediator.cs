using System;
using System.Collections.Generic;
using Events_POC.Colleagues;
using Events_POC.Events;

namespace Events_POC.Mediator
{
    public class MessageMediator : IMediator
    {
        private readonly List<Colleague> _observersContainer;

        public MessageMediator()
        {
            _observersContainer = new List<Colleague>();
        }

        public void Subscribe(Colleague colleague)
        {
            if (!_observersContainer.Contains(colleague))
            {
                _observersContainer.Add(colleague);
            }
        }

        public void Interact(Event @event)
        {
            var result = string.Empty;
            var eventColleague = @event.GetColleague();
            foreach (var colleagueItem in _observersContainer)
            {
                if (colleagueItem != eventColleague)
                    result += " ---- " +
                              $"{colleagueItem.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {eventColleague.GetType().Name} " +
                              $"with content: {eventColleague.GetMessage()}\n";
            }

            Console.WriteLine(result);
        }

        public IEnumerable<Colleague> GetColleagues()
        {
            return this._observersContainer;
        }
    }
}
