using DesignByContract.Domain.Core.Interfaces.Notifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Notifications
{
    [TestClass]
    public class NotificationFakeForInterfacesTests : NotificationAbstractFakeForInterfacesTests
    {
        public override INotification GetNotificationInstance()
        {
            return new NotificationFakeForInterfaces();
        }
    }
}