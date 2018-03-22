using DesignByContract.Domain.Core.Interfaces.Notifications;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Notifications
{
    [TestFixture]
    public abstract class ItemDetailAbstractFakeForInterfacesTests
    {
        public abstract IItemDetail GetItemDetailInstance(string message, params string[] args);


        [Test]
        public void ItemDetailMessageReturnString()
        {
            var entity = GetItemDetailInstance("Test {0} {1}", "Arg1", "Arg2");
            Assert.IsTrue(entity.Message == "Test Arg1 Arg2");
        }

        [Test]
        public void ItemDetailToStringReturnString()
        {
            var entity = GetItemDetailInstance("Test {0} {1}", "Arg1", "Arg2");
            Assert.IsTrue(entity.ToString() == "Test Arg1 Arg2");
        }
    }
}