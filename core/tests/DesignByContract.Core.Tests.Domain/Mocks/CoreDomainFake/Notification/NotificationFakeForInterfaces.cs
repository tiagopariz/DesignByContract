using System.Collections.Generic;
using System.Linq;
using DesignByContract.Core.Domain.Interfaces.Notifications;
using DesignByContract.Core.Domain.Notifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notification
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