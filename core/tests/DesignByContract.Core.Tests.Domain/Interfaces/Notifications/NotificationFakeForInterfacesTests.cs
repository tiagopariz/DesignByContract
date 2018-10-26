using DesignByContract.Core.Domain.Interfaces.Notifications;
using DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notifications;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Notifications
{
    [TestFixture]
    public class NotificationFakeForInterfacesTests : NotificationAbstractFakeForInterfacesTests
    {
        public override INotification GetNotificationInstance()
        {
            return new NotificationFakeForInterfaces();
        }
    }
}