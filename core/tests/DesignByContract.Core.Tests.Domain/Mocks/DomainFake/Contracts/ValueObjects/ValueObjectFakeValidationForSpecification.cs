using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.ValueObjects
{
    public class ValueObjectFakeValidationForSpecification<T> : Specification<T>
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 15;
        public const bool NameRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var valueObjectFakeForSpecification = candidate as ValueObjectFakeForSpecification;

            if (string.IsNullOrEmpty(valueObjectFakeForSpecification?.Name))
                valueObjectFakeForSpecification?.ErrorList.Add(
                    new ErrorItemDetail("The Name is required.",
                                        new Critical(),
                                        valueObjectFakeForSpecification.FieldName));

            if ((valueObjectFakeForSpecification?.Name ?? "").Length < NameMinLength)
                valueObjectFakeForSpecification?.ErrorList.Add(
                    new ErrorItemDetail("Min error",
                                        new Critical(),
                                        valueObjectFakeForSpecification.FieldName));

            if ((valueObjectFakeForSpecification?.Name ?? "").Length > NameMaxLength)
                valueObjectFakeForSpecification?.ErrorList.Add(
                    new ErrorItemDetail("Max error",
                                        new Critical(),
                                        valueObjectFakeForSpecification.FieldName));

            return !valueObjectFakeForSpecification?.ErrorList.HasCriticals ?? false;
        }
    }
}