﻿using Events_POC.Mediator;

namespace Events_POC.Colleagues
{
    public abstract class Colleague
    {
        protected IMediator mediator;
        protected string message;

        protected Colleague(IMediator mediator)
        {
            this.mediator = mediator;
            mediator.Subscribe(this);
        }

        public abstract void SendMessage(string message);

        public string GetMessage()
        {
            return this.message;
        }
    }
}