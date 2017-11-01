using System;

namespace OrderProcessorService
{ 
    public abstract class Message
    {
        public string CorrelationId { get; set; }  
        
        public abstract string Subject { get; }      

        public Message()
        {
            CorrelationId = Guid.NewGuid().ToString();
        }
    }

    public class OrderPlacedEvent : Message
    {
        public const string Name = "OrderPlaced";

        public override string Subject => Name;
    }
}
