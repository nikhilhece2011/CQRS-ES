using MediatR;
using MediatrExample.Domain.Models;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrExample.Domain.Notifications
{
    public class ProductRegisteredNotification : INotificationHandler<Product>
    {
        public async Task Handle(Product notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine(notification.Name);
        }
    }
}
