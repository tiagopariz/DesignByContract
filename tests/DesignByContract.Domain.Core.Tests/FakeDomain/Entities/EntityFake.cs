using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Tests.FakeDomain.Contracts.Entities;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.Entities
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