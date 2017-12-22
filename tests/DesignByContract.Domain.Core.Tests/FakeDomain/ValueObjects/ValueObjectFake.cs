using DesignByContract.Domain.Core.Tests.FakeDomain.Contracts.ValueObjects;
using DesignByContract.Domain.Core.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects
{
    public class ValueObjectFake : ValueObject
    {
        public const int NameMinLength = ValueObjectFakeValidation<object>.NameMinLength;
        public const int NameMaxLength = ValueObjectFakeValidation<object>.NameMaxLength;
        public const bool NameRequired = ValueObjectFakeValidation<object>.NameRequired;

        public ValueObjectFake(string name, string fieldName = null)
            : base(fieldName)
        {
            Name = name;
            Validate();
        }

        private void Validate()
        {
            ValidSpecification = new ValueObjectFakeValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}