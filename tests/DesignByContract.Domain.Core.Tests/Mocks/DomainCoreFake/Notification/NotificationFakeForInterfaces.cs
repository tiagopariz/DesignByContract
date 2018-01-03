using DesignByContract.Domain.Core.Interfaces.Notifications;
using DesignByContract.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification
{
    public class NotificationFakeForInterfaces : INotification
    {
        public IList<object> List { get; } = new List<object>();
        public bool Any => List.Any();

        public bool Includes(ItemDetail itemDetail)
        {
            return List.Contains(itemDetail);
        }

        public void Add(ItemDetail description)
        {
            List.Add(description);
        }

        public void Concat(params INotification[] args)
        {
            foreach (var notification in args)
            {
                if (notification?.List == null) continue;
                foreach (var description in notification.List)
                    List.Add(description);
            }
        }
    }
}