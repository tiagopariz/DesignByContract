using DesignByContract.Core.Domain.ValueObjects;
using DesignByContract.Domain.Contracts.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public const int NameMinLength = PersonNameValidation<object>.NameMinLength;
        public const int NameMaxLength = PersonNameValidation<object>.NameMaxLength;
        public const bool NameRequired = PersonNameValidation<object>.NameRequired;

        public PersonName(string name, string fieldName = null)
            : base(fieldName)
        {
            Name = name;
            Validate();
        }

        private void Validate()
        {
            ValidSpecification = new PersonNameValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}