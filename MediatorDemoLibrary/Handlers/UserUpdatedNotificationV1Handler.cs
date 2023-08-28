using MediatorDemoLibrary.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDemoLibrary.Handlers
{
    public class UserUpdatedNotificationV1Handler:INotificationHandler<UserUpdateNotification>
    {
        
        public Task Handle(UserUpdateNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"V1 ID::{notification.message} ");
            return Task.CompletedTask;
        }
    }
}
