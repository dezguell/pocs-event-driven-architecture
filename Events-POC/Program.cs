using Asset;
using Book;
using Common.Mediator;
using DataImport;
using LocalMediator;

namespace Events_POC
{
    class Program
    {
        // Starting Services 
        private static IMediator mediator = new Mediator();
        private static AssetService assetService = new(mediator);
        private static BookService bookService = new(mediator);
        private static DataImportService dataImportService = new(mediator);


        static void Main(string[] args)
        {
            //All services will send a message to the service group
            SendMessages();
            
            //The DataImport Service will send a request for persisting a new asset
            SendAssetCreationRequest();
            Console.ReadKey();
        }

        private static void SendMessages()
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var service in mediator.GetServices())
            {
                Console.Write($" -- {service.GetType().Name}: ");
                service.SendMessage(Console.ReadLine());
                Console.WriteLine("-----------------------");
            }
        }

        private static void SendAssetCreationRequest()
        {
            Console.WriteLine("Sending assetCreation Requests : ");
            dataImportService.SendAssetCreationRequest(Guid.NewGuid(),"assetTypeValue", 3000);
        }
    }
}
