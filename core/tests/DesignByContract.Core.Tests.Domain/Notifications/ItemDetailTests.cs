using DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Notifications;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Notifications
{
    [TestFixture]
    public class ItemDetailTests
    {
        [Test]
        public void ItemDetailNewMessage()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification");
            Assert.AreEqual("Test notitification", itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewEmptyMessage()
        {
            var itemDetailFake = new ItemDetailFake("");
            Assert.AreEqual("", itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewNullMessage()
        {
            var itemDetailFake = new ItemDetailFake(null);
            Assert.AreEqual(null, itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification {0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Test notitification Arg1 Arg2", itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewEmptyMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("{0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Arg1 Arg2", itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewNullMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake(null, "Arg1", "Arg2");
            Assert.AreEqual(null, itemDetailFake.Message);
        }

        [Test]
        public void ItemDetailNewMessageToString()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification");
            Assert.AreEqual("Test notitification", itemDetailFake.ToString());
        }

        [Test]
        public void ItemDetailNewMessageToStringWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification {0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Test notitification Arg1 Arg2", itemDetailFake.ToString());
        }
    }
}