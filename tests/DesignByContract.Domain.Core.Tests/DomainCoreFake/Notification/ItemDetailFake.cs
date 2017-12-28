using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Tests.DomainCoreFake.Notification
{
    public class ItemDetailFake : ItemDetail
    {
        public ItemDetailFake(string message, params string[] args)
            : base(message, args)
        {

        }
    }
}