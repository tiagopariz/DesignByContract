using DesignByContract.Domain.Core.Interfaces.Specifications;

namespace DesignByContract.Domain.Core.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _notSpecification;

        public NotSpecification(ISpecification<T> not)
        {
            _notSpecification = not;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            !_notSpecification.IsSatisfiedBy(candidate);
    }
}