using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Interfaces.Entities;
using NUnit.Framework;
using System;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Entities
{
    [TestFixture]
    public abstract class EntityAbstractFakeForInterfacesTests
    {
        public abstract IEntity GetEntityInstanceParseEmptyId();
        public abstract IEntity GetEntityInstanceParseValidId();

        [Test]
        public void EntityParseEmptyIdReturnValidGuid()
        {
            var entity = GetEntityInstanceParseEmptyId();
            var id = entity.Id;
            Assert.IsTrue(Guid.Empty != id);
        }

        [Test]
        public void EntityParseValidIdReturnValidGuid()
        {
            var entity = GetEntityInstanceParseValidId();
            var id = entity.Id;
            Assert.IsTrue(Guid.Empty != id);
        }

        [Test]
        public void EntityErrorListAddReturnAnyTrue()
        {
            var entity = GetEntityInstanceParseValidId();
            var errorList = entity.ErrorList;
            errorList.Add(new ErrorItemDetail("Test", new Critical(), ""));
            Assert.IsTrue(errorList.Any);
        }

        [Test]
        public void EntityValidSpecificationReturnSpecificarion()
        {
            var entity = GetEntityInstanceParseValidId();
            var validation = entity.ValidSpecification;
            Assert.IsTrue(validation != null);
        }

        [Test]
        public void EntityFieldNameReturnClassName()
        {
            var entity = GetEntityInstanceParseValidId();
            Assert.IsTrue(entity.FieldName == "EntityFakeForInterfaces");
        }
    }
}