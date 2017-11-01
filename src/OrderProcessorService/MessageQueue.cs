using System;
using NATS.Client;

namespace OrderProcessorService
{
    public class MessageQueue
    {
        public static IConnection CreateConnection()
        {
            return new ConnectionFactory().CreateConnection(Config.MessageQueueUrl);
        }
    }
}