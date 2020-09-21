using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRCore.Config.Events
{
    public class CustomerCreatedEmailSenderHandler : INotificationHandler<CustomerCreatedEvent>
    {

        public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !");
            return Task.CompletedTask;
        }
    }
}
