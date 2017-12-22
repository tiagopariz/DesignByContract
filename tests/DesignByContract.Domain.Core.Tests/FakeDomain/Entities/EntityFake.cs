using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Tests.FakeDomain.Specifications.Entities;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.Entities
{
    public class EntityFake : Entity
    {
        public const bool ValueObjectFakeRequired = EntityFakeValidSpecification<object>.ValueObjectFakeRequired;

        public EntityFake(Guid id,
                          ValueObjectFake valueObjectFake,
                          string fieldName = null) 
            : base(id, fieldName)
        {

            ValueObjectFake = valueObjectFake;

            ValueObjectFake?.SetFieldName(GetPropertyName(() => ValueObjectFake));

            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new EntityFakeValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public ValueObjectFake ValueObjectFake { get; }
    }
}