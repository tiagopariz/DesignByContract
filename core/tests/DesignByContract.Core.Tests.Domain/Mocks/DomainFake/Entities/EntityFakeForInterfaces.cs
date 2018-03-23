using DesignByContract.Core.Domain.Entities;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.Entities;
using System;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities
{
    public class EntityFakeForInterfaces : Entity
    {
        public EntityFakeForInterfaces(Guid id, string fieldname = "EntityFakeForInterfaces") :
            base(id, fieldname)
        {
            ValidSpecification = new EntityFakeValidationForInterfaces<object>();
        }
    }
}