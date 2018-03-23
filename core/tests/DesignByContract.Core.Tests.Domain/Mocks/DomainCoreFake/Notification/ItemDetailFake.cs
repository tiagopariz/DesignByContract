using DesignByContract.Core.Domain.Notifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainCoreFake.Notification
{
    public class ItemDetailFake : ItemDetail
    {
        public ItemDetailFake(string message, params string[] args)
            : base(message, args)
        {

        }
    }
}