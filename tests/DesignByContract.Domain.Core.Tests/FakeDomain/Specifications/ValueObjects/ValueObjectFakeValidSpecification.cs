using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.Specifications.ValueObjects
{
    public class ValueObjectFakeValidSpecification<T> : CompositeSpecification<T>
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 255;
        public const bool NameRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var email = candidate as ValueObjectFake;

            if (string.IsNullOrEmpty(email?.Name))
                email?.ErrorList.Add(
                    new ErrorItemDetail("The Name is required.",
                                        new Critical(),
                                        email.FieldName));

            if ((email?.Name ?? "").Length < NameMinLength)
                email?.ErrorList.Add(
                    new ErrorItemDetail("Min error",
                                        new Critical(),
                                        email.FieldName));

            if ((email?.Name ?? "").Length > NameMaxLength)
                email?.ErrorList.Add(
                    new ErrorItemDetail("Max error",
                                        new Critical(),
                                        email.FieldName));

            return !email?.ErrorList.HasCriticals ?? false;
        }
    }
}