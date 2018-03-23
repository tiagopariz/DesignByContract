using DesignByContract.Core.Domain.Entities;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.Entities;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using System;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities
{
    public class EntityFake : Entity
    {
        public const bool ValueObjectFakeRequired = EntityFakeValidation<object>.ValueObjectFakeRequired;

        public EntityFake(Guid id,
                          ValueObjectFake valueObjectFake,
                          string fieldName = null)
            : base(id, fieldName)
        {

            ValueObjectFake = valueObjectFake;

            ValueObjectFake?.SetFieldName(GetPropertyName(() => ValueObjectFake));

            Validate();
        }

        private void Validate()
        {
            ValidSpecification = new EntityFakeValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public ValueObjectFake ValueObjectFake { get; }
    }
}