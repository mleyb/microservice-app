using Newtonsoft.Json;
using System.Text;

namespace OrderProcessorService
{
    public class MessageHelper
    {
        public static TMessage FromData<TMessage>(byte[] data)
            where TMessage : Message
        {
            var json = Encoding.Unicode.GetString(data);
            return (TMessage)JsonConvert.DeserializeObject<TMessage>(json);
        }
    }
}
