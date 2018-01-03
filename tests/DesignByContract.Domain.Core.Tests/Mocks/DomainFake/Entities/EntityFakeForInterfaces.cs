using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.Entities;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities
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