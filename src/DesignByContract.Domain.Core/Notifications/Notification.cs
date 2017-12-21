using DesignByContract.Domain.Core.Interfaces.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DesignByContract.Domain.Core.Notifications
{
    public abstract class Notification : INotification
    {
        // TODO: Tornar lista somente acessível pelo Add e Concat
        public IList<object> List { get; } = new List<object>();
        public bool Any => List.Any();

        public bool Includes(ItemDetail error)
        {
            return List.Contains(error);
        }

        public void Add(ItemDetail description)
        {
            List.Add(description);
        }

        public void Concat(params Notification[] args)
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