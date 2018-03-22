using DesignByContract.Domain.Core.Interfaces.Entities;
using NUnit.Framework;
using System;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Entities
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