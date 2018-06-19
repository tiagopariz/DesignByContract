using System.Collections.Generic;

namespace DesignByContract.Core.Domain.Interfaces.Notifications
{
    public interface INotification
    {
        IReadOnlyList<object> List { get; }
        bool Any { get; }
        bool Includes(IItemDetail itemDetail);
        void Add(IItemDetail itemDetail);
        void Concat(params INotification[] args);
    }
}