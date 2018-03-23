using DesignByContract.Core.Domain.Interfaces.Notifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainCoreFake.Notification;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Notifications
{
    [TestFixture]
    public class ItemDetailFakeForInterfacesTests : ItemDetailAbstractFakeForInterfacesTests
    {
        public override IItemDetail GetItemDetailInstance(string message, params string[] args)
        {
            return new ItemDetailFakeForInterfaces(message, args);
        }
    }
}