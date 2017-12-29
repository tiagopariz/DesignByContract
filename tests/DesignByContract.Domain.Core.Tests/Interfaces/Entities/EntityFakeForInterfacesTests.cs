using DesignByContract.Domain.Core.Interfaces.Entities;
using DesignByContract.Domain.Core.Tests.DomainFake.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Entities
{
    [TestClass]
    public class EntityFakeForInterfacesTests : AbstractFakeForInterfacesTests
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