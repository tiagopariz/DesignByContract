using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification
{
    public class ItemDetailFake : ItemDetail
    {
        public ItemDetailFake(string message, params string[] args)
            : base(message, args)
        {

        }
    }
}