using System;
using Asset;
using Book;
using Common;
using Common.Mediator;
using DataImport;

namespace Events_POC
{
    class Program
    {
        private static IMediator mediator = new ServicesMediator();
        private static AssetService AsetService = new AssetService(mediator);
        private static BookService BookService = new BookService(mediator);
        private static DataImportService DataImport = new DataImportService(mediator);


        static void Main(string[] args)
        {
            SendMessages();
            SendInteractionRequest();
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

        private static void SendInteractionRequest()
        {
            Console.WriteLine("Sending assetCreation Requests : ");
            DataImport.SendAssetCreationRequest();
        }
    }
}
