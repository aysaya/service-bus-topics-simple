using QuoteEngine.ResourceAccessors;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicQueueSender.MessageHandlers
{
    public interface IHandleMessage
    {
        Task Handle(Message message, CancellationToken token);
        Task HandleOption(ExceptionReceivedEventArgs arg);
    }
    public class MessageHandler : IHandleMessage
    {
        private readonly ICommandRA commandRA;

        public MessageHandler(ICommandRA commandRA)
        {
            this.commandRA = commandRA;
        }

        public async Task Handle(Message message, CancellationToken token)
        {
            var payload = JsonConvert.DeserializeObject<object>(Encoding.UTF8.GetString(message.Body));
            await commandRA.SaveAsync(payload);
        }

        public Task HandleOption(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler encountered an exception {arg.Exception}.");
            return Task.CompletedTask;
        }

    }
}
