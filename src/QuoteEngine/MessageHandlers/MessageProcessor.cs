using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using QuoteEngine.ResourceAccessors;
using System.Text;
using System.Threading.Tasks;

namespace QuoteEngine.MessageHandlers
{
    public interface IProcessMessage
    {
        Task Process(Message message);
    }
    public class MessageProcessor : IProcessMessage
    {
        private readonly ICommandRA commandRA;
        private readonly IPublishMessage messagePublisher;

        public MessageProcessor(ICommandRA commandRA, IPublishMessage messagePublisher)
        {
            this.commandRA = commandRA;
            this.messagePublisher = messagePublisher;
        }
        public async Task Process(Message message)
        {
            var payload = JsonConvert.DeserializeObject<object>(Encoding.UTF8.GetString(message.Body));
            await commandRA.SaveAsync(payload);
        }
    }
}
