﻿using DesignByContract.Core.Domain.Interfaces.Notifications;
using DesignByContract.Core.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notification
{
    public class NotificationFakeForInterfaces : INotification
    {
        private readonly IList<object> _list = new List<object>();
        public IReadOnlyList<object> List => _list.ToArray();
        public bool Any => List.Any();

        public bool Includes(ItemDetail itemDetail)
        {
            return List.Contains(itemDetail);
        }

        public void Add(ItemDetail description)
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