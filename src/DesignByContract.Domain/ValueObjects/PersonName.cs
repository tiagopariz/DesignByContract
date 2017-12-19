using DesignByContract.Domain.Core.ValueObjects;
using DesignByContract.Domain.Specifications.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public const int NameMinLength = PersonNameValidSpecification<object>.NameMinLength;
        public const int NameMaxLength = PersonNameValidSpecification<object>.NameMinLength;

        public PersonName(string name, bool isRequired = false)
        {
            Name = name;
            Validate(isRequired);
        }

        public sealed override void Validate(bool isRequired)
        {
            ValidSpecification = new PersonNameValidSpecification<object>(isRequired);
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Name { get; }

        public override string ToString() => Name;
    }
}