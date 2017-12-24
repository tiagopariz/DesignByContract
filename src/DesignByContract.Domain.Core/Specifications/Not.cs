using DesignByContract.Domain.Core.Interfaces.Specifications;

namespace DesignByContract.Domain.Core.Specifications
{
    public class Not<T> : Specification<T>
    {
        private readonly ISpecification<T> _not;

        public Not(ISpecification<T> not)
        {
            _not = not;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            !_not.IsSatisfiedBy(candidate);
    }
}