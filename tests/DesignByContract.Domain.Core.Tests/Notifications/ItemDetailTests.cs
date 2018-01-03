using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Notification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Notifications
{
    [TestClass]
    public class ItemDetailTests
    {
        [TestMethod]
        public void ItemDetailNewMessage()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification");
            Assert.AreEqual("Test notitification", itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewEmptyMessage()
        {
            var itemDetailFake = new ItemDetailFake("");
            Assert.AreEqual("", itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewNullMessage()
        {
            var itemDetailFake = new ItemDetailFake(null);
            Assert.AreEqual(null, itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification {0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Test notitification Arg1 Arg2", itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewEmptyMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("{0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Arg1 Arg2", itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewNullMessageWithArgs()
        {
            var itemDetailFake = new ItemDetailFake(null, "Arg1", "Arg2");
            Assert.AreEqual(null, itemDetailFake.Message);
        }

        [TestMethod]
        public void ItemDetailNewMessageToString()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification");
            Assert.AreEqual("Test notitification", itemDetailFake.ToString());
        }

        [TestMethod]
        public void ItemDetailNewMessageToStringWithArgs()
        {
            var itemDetailFake = new ItemDetailFake("Test notitification {0} {1}", "Arg1", "Arg2");
            Assert.AreEqual("Test notitification Arg1 Arg2", itemDetailFake.ToString());
        }
    }
}