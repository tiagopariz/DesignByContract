using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Entities
{
    [TestClass]
    public abstract class EntityAbstractFakeForInterfacesTests
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

        [TestMethod]
        public void EntityErrorListAddReturnAnyTrue()
        {
            var entity = GetEntityInstanceParseValidId();
            var errorList = entity.ErrorList;
            errorList.Add(new ErrorItemDetail("Test", new Critical(), ""));
            Assert.IsTrue(errorList.Any);
        }

        [TestMethod]
        public void EntityValidSpecificationReturnSpecificarion()
        {
            var entity = GetEntityInstanceParseValidId();
            var validation = entity.ValidSpecification;
            Assert.IsTrue(validation != null);
        }

        [TestMethod]
        public void EntityFieldNameReturnClassName()
        {
            var entity = GetEntityInstanceParseValidId();
            Assert.IsTrue(entity.FieldName == "EntityFakeForInterfaces");
        }
    }
}