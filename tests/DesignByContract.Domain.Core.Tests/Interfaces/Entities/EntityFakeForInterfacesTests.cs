using DesignByContract.Domain.Core.Interfaces.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Entities
{
    [TestClass]
    public class EntityFakeForInterfacesTests : EntityAbstractFakeForInterfacesTests
    {
        public override IEntity GetEntityInstanceParseEmptyId()
        {
            return new EntityFakeForInterfaces(Guid.Empty);
        }

        public override IEntity GetEntityInstanceParseValidId()
        {
            return new EntityFakeForInterfaces(Guid.NewGuid());
        }
    }
}