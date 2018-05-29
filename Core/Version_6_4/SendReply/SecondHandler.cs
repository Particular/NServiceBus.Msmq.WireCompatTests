﻿using System.Threading.Tasks;
using CommonMessages;
using NServiceBus;

namespace Common.SendReply
{
    public class SecondHandler : IHandleMessages<SendReplySecondMessage>
    {
        public Task Handle(SendReplySecondMessage message, IMessageHandlerContext context)
        {
            SendReplyVerifier.SecondMessageReceivedFrom.Add(message.Sender);
            return Task.FromResult(0);
        }
    }
}