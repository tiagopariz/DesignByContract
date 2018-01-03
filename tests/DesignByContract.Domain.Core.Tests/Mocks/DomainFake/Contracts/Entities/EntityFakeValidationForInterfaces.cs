using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.Entities
{
    public class EntityFakeValidationForInterfaces<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T candidate)
        {
            return true;
        }
    }
}