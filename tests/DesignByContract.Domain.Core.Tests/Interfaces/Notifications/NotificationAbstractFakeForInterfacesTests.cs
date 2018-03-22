using DesignByContract.Domain.Core.Interfaces.Notifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Notifications
{
    [TestFixture]
    public abstract class NotificationAbstractFakeForInterfacesTests
    {
        public abstract INotification GetNotificationInstance();
        
        [Test]
        public void NotificationListAddItemDetailReturnIncludesTrue()
        {
            var entity = GetNotificationInstance();
            var itemDetail = new ItemDetailFake("Test");
            entity.List.Add(itemDetail);
            Assert.IsTrue(entity.Includes(itemDetail));
        }

        [Test]
        public void NotificationListReturnAnyTrue()
        {
            var entity = GetNotificationInstance();
            var itemDetail = new ItemDetailFake("Test");
            entity.Add(itemDetail);
            Assert.IsTrue(entity.Any);
        }

        [Test]
        public void NotificationListAddItemDetailReturnIncludesFalse()
        {
            var entity = GetNotificationInstance();
            var itemDetail1 = new ItemDetailFake("Test1");
            var itemDetail2 = new ItemDetailFake("Test2");
            entity.List.Add(itemDetail1);
            Assert.IsFalse(entity.Includes(itemDetail2));
        }

        [Test]
        public void NotificationAddItemDetailReturnIncludesTrue()
        {
            var entity = GetNotificationInstance();
            var itemDetail = new ItemDetailFake("Test");
            entity.Add(itemDetail);
            Assert.IsTrue(entity.Includes(itemDetail));
        }

        [Test]
        public void NotificationAddItemDetailReturnIncludesFalse()
        {
            var entity = GetNotificationInstance();
            var itemDetail1 = new ItemDetailFake("Test1");
            var itemDetail2 = new ItemDetailFake("Test2");
            entity.Add(itemDetail1);
            Assert.IsFalse(entity.Includes(itemDetail2));
        }

        [Test]
        public void NotificationConcatItemDetailReturnCount2()
        {
            var entity1 = GetNotificationInstance();
            var entity2 = new NotificationFakeForInterfaces();
            entity1.Add(new ItemDetailFake("Test1"));
            entity2.Add(new ItemDetailFake("Test2"));
            entity2.Concat(entity1);
            Assert.AreEqual(entity2.List.Count, 2);
        }
    }
}