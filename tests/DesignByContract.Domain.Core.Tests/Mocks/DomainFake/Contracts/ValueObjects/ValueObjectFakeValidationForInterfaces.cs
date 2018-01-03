using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.ValueObjects
{
    public class ValueObjectFakeValidationForInterfaces<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T candidate)
        {
            return true;
        }
    }
}