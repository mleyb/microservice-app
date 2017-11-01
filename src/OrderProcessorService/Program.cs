using System;
using System.Linq;
using System.Threading;
using NATS.Client;

namespace OrderProcessorService
{
    class Program
    {
        private const string MessageSubject = "OrderPlaced";

        private static readonly ManualResetEvent _resetEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine($"Connecting to message queue url: {Config.MessageQueueUrl}");

            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(MessageSubject);

                subscription.MessageHandler += HandlePlacedOrder;

                subscription.Start();

                Console.WriteLine($"Listening on subject: {MessageSubject}");

                _resetEvent.WaitOne();

                connection.Close();
            }
        }

        private static void HandlePlacedOrder(object sender, MsgHandlerEventArgs e)
        {
            Console.WriteLine($"Received message, subject: {e.Message.Subject}");

            // do some order handling stuff...

            Console.WriteLine("Order placed!");
        }
    }
}
