using System;
using System.Collections.Generic;
using System.Linq;
using Events_POC.Events;
using Events_POC.Services;

namespace Events_POC.Mediator
{
    public class ServicesMediator : IMediator
    {
        private readonly Dictionary<Service, Event[]> _serviceContainer;

        public ServicesMediator()
        {
            _serviceContainer = new Dictionary<Service, Event[]>();
        }

        public void Subscribe(KeyValuePair<Service, Event[]> service)
        {
            if (!_serviceContainer.ContainsKey(service.Key))
            {
                _serviceContainer.Add(service.Key, service.Value);
            }
            else
            {
                _serviceContainer[service.Key].ToList().AddRange(service.Value);
            }
        }

        public void Interact(SendMessageEvent @event)
        {
            var eventColleague = @event.GetService();
            foreach (var colleagueItem in _serviceContainer)
            {
                if (colleagueItem.Key != eventColleague)
                    colleagueItem.Key.React(@event);
            }
        }

        public void Interact(SendInteractionRequestEvent @event)
        {
            var eventServiceTo = @event.GetColleagueTo();

            if (GetColleagues().Contains(eventServiceTo))
            {
                if (_serviceContainer[eventServiceTo].Select(e => e.GetType().Name)
                    .Contains(@event.GetType().Name))
                {
                    eventServiceTo.React(@event);
                }
                else
                {
                    Console.WriteLine(" ---- " +
                                      $"{eventServiceTo.GetType().Name} " +
                                      $"wasn't notified of: {@event.GetType().Name} " +
                                      $"from: {@event.GetService().GetType().Name} " +
                                      "because he/she is not subscribed for this event\n");
                }
            }

        }

        public void Interact(AnswerInteractionRequestEvent @event)
        {
            @event.GetService().React(@event);
        }

        public IEnumerable<Service> GetColleagues()
        {
            return this._serviceContainer.Keys;
        }
    }
}
