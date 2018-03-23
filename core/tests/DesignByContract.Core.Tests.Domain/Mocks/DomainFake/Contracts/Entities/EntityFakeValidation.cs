using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.Entities
{
    public class EntityFakeValidation<T> : Specification<T>
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