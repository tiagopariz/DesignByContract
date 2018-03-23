using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.ValueObjects
{
    public class ValueObjectFakeValidation<T> : Specification<T>
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 15;
        public const bool NameRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var valueObjectFake = candidate as ValueObjectFake;

            if (string.IsNullOrEmpty(valueObjectFake?.Name))
                valueObjectFake?.ErrorList.Add(
                    new ErrorItemDetail("The Name is required.",
                                        new Critical(),
                                        valueObjectFake.FieldName));

            if ((valueObjectFake?.Name ?? "").Length < NameMinLength)
                valueObjectFake?.ErrorList.Add(
                    new ErrorItemDetail("Min error",
                                        new Critical(),
                                        valueObjectFake.FieldName));

            if ((valueObjectFake?.Name ?? "").Length > NameMaxLength)
                valueObjectFake?.ErrorList.Add(
                    new ErrorItemDetail("Max error",
                                        new Critical(),
                                        valueObjectFake.FieldName));

            return !valueObjectFake?.ErrorList.HasCriticals ?? false;
        }
    }
}