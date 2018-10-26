using System.Collections.Generic;
using System.Linq;
using DesignByContract.Core.Domain.Interfaces.Notifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notifications
{
    public class NotificationFakeForInterfaces : INotification
    {
        private readonly IList<object> _list = new List<object>();
        public IReadOnlyList<object> List => _list.ToArray();
        public bool Any => List.Any();

        public bool Includes(IItemDetail itemDetail)
        {
            return List.Contains(itemDetail);
        }

        public void Add(IItemDetail description)
        {
            _list.Add(description);
        }

        public void Concat(params INotification[] args)
        {
            foreach (var notification in args)
            {
                if (notification?.List == null) continue;
                foreach (var description in notification.List)
                    _list.Add(description);
            }
        }
    }
}