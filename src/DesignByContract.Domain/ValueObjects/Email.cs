using DesignByContract.Domain.Core.ValueObjects;
using DesignByContract.Domain.Specifications.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int AddressMinLength = EmailValidSpecification<object>.AddressMinLength;
        public const int AddressMaxLength = EmailValidSpecification<object>.AddressMinLength;

        public Email(string address, bool isRequired = false)
        {
            Address = address;
            Validate(isRequired);
        }

        public sealed override void Validate(bool isRequired)
        {
            ValidSpecification = new EmailValidSpecification<object>(isRequired);
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Address { get; }

        public override string ToString() => Address;
    }
}