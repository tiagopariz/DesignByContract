using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.DomainFake.Entities;

namespace DesignByContract.Domain.Core.Tests.DomainFake.Contracts.Entities
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