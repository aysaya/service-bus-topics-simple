﻿using Microsoft.Azure.ServiceBus;
using Pricing.DomainModel;
using Pricing.ResourceAccessors;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MessageHandlers
{
    public interface IProcessMessage
    {
        Task ProcessAsync(Message message);
    }
    public class MessageProcessor : IProcessMessage
    {
        private readonly ICommandRA commandRA;

        public MessageProcessor(ICommandRA commandRA)
        {
            this.commandRA = commandRA;
        }

        public async Task ProcessAsync(Message message)
        {
            var body = Encoding.UTF8.GetString(message.Body);

            await commandRA.SaveAsync(new Quote { Payload = body});
        }

    }
}
