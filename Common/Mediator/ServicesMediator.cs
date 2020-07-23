﻿using System.Collections.Generic;
using System.Linq;
using Common.Events;

namespace Common.Mediator
{
    public class ServicesMediator : IMediator
    {
        private readonly Dictionary<Service.Service, Event[]> _serviceContainer;

        public ServicesMediator()
        {
            _serviceContainer = new Dictionary<Service.Service, Event[]>();
        }

        public void Subscribe(KeyValuePair<Service.Service, Event[]> service)
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

        public void Interact(Event @event)
        {
            var servicesSubscribedToEvent = _serviceContainer
                .Where(colleague => colleague.Value
                    .Select(evnt => evnt.GetType().Name)
                    .Contains(@event.GetType().Name) && colleague.Key != @event.GetService());
            
            foreach (var service in servicesSubscribedToEvent)
            {
                service.Key.ReactTo(@event);
            }
        }

        public IEnumerable<Service.Service> GetServices()
        {
            return this._serviceContainer.Keys;
        }
    }
}
