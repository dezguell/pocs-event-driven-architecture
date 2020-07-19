using System;
using System.Collections.Generic;
using Events_POC.Colleagues;
using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC
{
    class Program
    {
        private static IMediator mediator = new MessageMediator();
        private static Colleague jon = new Jon(mediator);
        private static Colleague peter = new Peter(mediator);
        private static Colleague ema = new Ema(mediator);

        static void Main(string[] args)
        {
            SendMessages();
            SendFriendRequest();

            Console.ReadKey();
        }

        private static void SendMessages()
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var colleague in mediator.GetColleagues())
            {
                Console.Write($" -- {colleague.GetType().Name}: ");
                colleague.SendMessage(Console.ReadLine());
                Console.WriteLine("-----------------------");
            }
        }

        private static void SendFriendRequest()
        {
            Console.WriteLine("Sending Friend Requests : ");
            Console.WriteLine(" -- From Ema to Jon: ");
            ema.SendFriendRequestTo(jon);

            Console.WriteLine(" -- From Jon to Peter: ");
            jon.SendFriendRequestTo(peter);

            Console.WriteLine(" -- From Peter to Ema: ");
            peter.SendFriendRequestTo(ema);
            Console.WriteLine("-----------------------");
        }
    }
}
