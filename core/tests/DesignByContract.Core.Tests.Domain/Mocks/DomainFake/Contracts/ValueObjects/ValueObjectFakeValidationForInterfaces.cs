using DesignByContract.Core.Domain.Specifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.ValueObjects
{
    public class ValueObjectFakeValidationForInterfaces<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T candidate)
        {
            return true;
        }
    }
}