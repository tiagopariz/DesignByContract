using System.Collections.Generic;
using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Interfaces.Notifications
{
    public interface INotification
    {
        IList<object> List { get; }
        bool HasNotifications { get; }

        bool Includes(Description error);
        void Add(Description error);
    }
}