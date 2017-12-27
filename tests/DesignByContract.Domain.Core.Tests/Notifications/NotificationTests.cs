using DesignByContract.Domain.Core.Tests.Mocks;
using DesignByContract.Domain.Core.Tests.Mocks.Notification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Notifications
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void NotificationNewHasList()
        {
            var fake = new Fake { Name = "Test"};
            Assert.IsTrue(fake.NotificationFake != null);
        }

        [TestMethod]
        public void NotificationNewAnyReturnTrue()
        {
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.Add(new ItemDetailFake("Test"));
            Assert.IsTrue(fake.NotificationFake.Any);
        }

        [TestMethod]
        public void NotificationNewAnyReturnFalse()
        {
            var fake = new Fake { Name = "Test" };
            Assert.IsFalse(fake.NotificationFake.Any);
        }

        [TestMethod]
        public void NotificationNewListIncludeReturnTrue()
        {
            var required = new ItemDetailFake("The Name is required.");
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.Add(required);
            Assert.IsTrue(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewListIncludeReturnFalse()
        {
            var required = new ItemDetailFake("The Name is required.");
            var fake = new Fake { Name = "Test" };
            Assert.IsFalse(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewListAddReturnTrue()
        {
            var required = new ItemDetailFake("The Name is required.");
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.List.Add(required);
            Assert.IsTrue(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewListAddReturnFalse()
        {
            var required = new ItemDetailFake("The Name is required.");
            var requiredWarning = new ItemDetailFake("The Name is required.");
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.List.Add(requiredWarning);
            Assert.IsFalse(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewListAddWithArgsReturnTrue()
        {
            var required = new ItemDetailFake("The {0} is required.", "Name");
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.List.Add(required);
            Assert.IsTrue(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewListAddWithArgsReturnFalse()
        {
            var required = new ItemDetailFake("The {0} is required.", "Name");
            var requiredWarning = new ItemDetailFake("The {0} is required.", "Name");
            var fake = new Fake { Name = "Test" };
            fake.NotificationFake.List.Add(requiredWarning);
            Assert.IsFalse(fake.NotificationFake.Includes(required));
        }

        [TestMethod]
        public void NotificationNewConcatSuccess()
        {
            var requiredWarning = new ItemDetailFake("The Name is required.");
            var fake1 = new Fake { Name = "Test" };
            fake1.NotificationFake.Add(requiredWarning);

            var required = new ItemDetailFake("The Name is required.");
            var fake2 = new Fake { Name = "Test" };
            fake2.NotificationFake.Add(required);

            fake2.NotificationFake.Concat(fake1.NotificationFake);

            Assert.IsTrue(fake2.NotificationFake.Includes(required) && fake2.NotificationFake.Includes(requiredWarning));
        }
    }
}