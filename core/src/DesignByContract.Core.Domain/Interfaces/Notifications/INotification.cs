using DesignByContract.Core.Domain.Notifications;
using System.Collections.Generic;

namespace DesignByContract.Core.Domain.Interfaces.Notifications
{
    public interface INotification
    {
        IReadOnlyList<object> List { get; }
        bool Any { get; }

        bool Includes(ItemDetail itemDetail);
        void Add(ItemDetail itemDetail);
    }
}