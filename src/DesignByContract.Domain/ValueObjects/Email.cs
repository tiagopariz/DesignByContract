using DesignByContract.Domain.Core.ValueObjects;
using DesignByContract.Domain.Specifications.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int AddressMinLength = EmailValidSpecification<object>.AddressMinLength;
        public const int AddressMaxLength = EmailValidSpecification<object>.AddressMaxLength;
        public const bool AddressRequired = EmailValidSpecification<object>.AddressRequired;

        public Email(string address, string fieldName = null)
            : base(fieldName)
        {
            Address = address;
            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new EmailValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Address { get; }

        public override string ToString() => Address;
    }
}