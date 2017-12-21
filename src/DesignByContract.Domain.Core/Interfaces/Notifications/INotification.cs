using DesignByContract.Domain.Core.Notifications;
using System.Collections.Generic;

namespace DesignByContract.Domain.Core.Interfaces.Notifications
{
    public interface INotification
    {
        IList<object> List { get; }
        bool Any { get; }

        bool Includes(ItemDetail error);
        void Add(ItemDetail error);
    }
}