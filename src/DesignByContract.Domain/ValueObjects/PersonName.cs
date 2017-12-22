using DesignByContract.Domain.Core.ValueObjects;
using DesignByContract.Domain.Specifications.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public const int NameMinLength = PersonNameValidSpecification<object>.NameMinLength;
        public const int NameMaxLength = PersonNameValidSpecification<object>.NameMaxLength;
        public const bool NameRequired = PersonNameValidSpecification<object>.NameRequired;

        public PersonName(string name, string fieldName = null)
            : base(fieldName)
        {
            Name = name;
            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new PersonNameValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}