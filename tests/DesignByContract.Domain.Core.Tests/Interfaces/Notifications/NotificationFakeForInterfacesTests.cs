using DesignByContract.Domain.Core.Interfaces.Notifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Notifications
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