using DesignByContract.Domain.Core.Interfaces.Notifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Notifications
{
    [TestClass]
    public class ItemDetailFakeForInterfacesTests : ItemDetailAbstractFakeForInterfacesTests
    {
        public override IItemDetail GetItemDetailInstance(string message, params string[] args)
        {
            return new ItemDetailFakeForInterfaces(message, args);
        }
    }
}