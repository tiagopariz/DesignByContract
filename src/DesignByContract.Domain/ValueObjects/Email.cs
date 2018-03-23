using DesignByContract.Core.Domain.ValueObjects;
using DesignByContract.Domain.Contracts.ValueObjects;

namespace DesignByContract.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int AddressMinLength = EmailValidation<object>.AddressMinLength;
        public const int AddressMaxLength = EmailValidation<object>.AddressMaxLength;
        public const bool AddressRequired = EmailValidation<object>.AddressRequired;

        public Email(string address, string fieldName = null)
            : base(fieldName)
        {
            Address = address;
            Validate();
        }

        private void Validate()
        {
            ValidSpecification = new EmailValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Address { get; }

        public override string ToString() => Address;
    }
}