using DesignByContract.Domain.Core.Interfaces.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Entities
{
    [TestClass]
    public abstract class AbstractFakeForInterfacesTests
    {
        public abstract IEntity GetEntityInstanceParseEmptyId();
        public abstract IEntity GetEntityInstanceParseValidId();

        [TestMethod]
        public void EntityParseEmptyIdReturnValidGuid()
        {
            var entity = GetEntityInstanceParseEmptyId();
            var id = entity.Id;
            Assert.IsTrue(Guid.Empty != id);
        }

        [TestMethod]
        public void EntityParseValidIdReturnValidGuid()
        {
            var entity = GetEntityInstanceParseValidId();
            var id = entity.Id;
            Assert.IsTrue(Guid.Empty != id);
        }
    }
}