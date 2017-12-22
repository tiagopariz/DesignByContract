using DesignByContract.Domain.Core.Tests.FakeDomain.Specifications.ValueObjects;
using DesignByContract.Domain.Core.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects
{
    public class ValueObjectFake : ValueObject
    {
        public const int NameMinLength = ValueObjectFakeValidSpecification<object>.NameMinLength;
        public const int NameMaxLength = ValueObjectFakeValidSpecification<object>.NameMaxLength;
        public const bool NameRequired = ValueObjectFakeValidSpecification<object>.NameRequired;

        public ValueObjectFake(string name, string fieldName = null)
            : base(fieldName)
        {
            Name = name;
            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new ValueObjectFakeValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}
