using DesignByContract.Core.Domain.Specifications;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.Entities
{
    public class EntityFakeValidationForInterfaces<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T candidate)
        {
            return true;
        }
    }
}