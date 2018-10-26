using DesignByContract.Core.Domain.Notifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notifications
{
    public class ItemDetailFake : ItemDetail
    {
        public ItemDetailFake(string message, params string[] args)
            : base(message, args)
        {
        }
    }
}