using DesignByContract.Core.Domain.Interfaces.Entities;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities;
using NUnit.Framework;
using System;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Entities
{
    [TestFixture]
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