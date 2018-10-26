using DesignByContract.Core.Tests.Application.Mocks.ApplicationFake.Services.Entities;
using DesignByContract.Core.Tests.Application.Mocks.DomainFake.Entities;
using NUnit.Framework;
using System;

namespace DesignByContract.Core.Tests.Application.Services
{
    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void ServiceNew()
        {
            var entity = new EntityFake(Guid.NewGuid());
            var sut = new EntityFakeService(entity);
            sut.SaveEntityFake();
        }

        [Test]
        public void TestEmpty()
        {
            Assert.AreEqual(true, true);
        }
    }
}