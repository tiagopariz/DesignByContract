using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.FakeDomain.Entities;

namespace DesignByContract.Domain.Core.Tests.FakeDomain.Specifications.Entities
{
    public class EntityFakeValidSpecification<T> : CompositeSpecification<T>
    {
        public const bool ValueObjectFakeRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var entityFake = candidate as EntityFake;

            if (string.IsNullOrEmpty(entityFake?.ValueObjectFake?.ToString()))
                entityFake?.ErrorList.Add(
                    new ErrorItemDetail("{0} is required",
                                        new Critical(),
                                        "Name",
                                        "Name"));

            return !entityFake?.ErrorList.HasCriticals ?? false;
        }
    }
}