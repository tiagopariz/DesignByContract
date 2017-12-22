using DesignByContract.Domain.Core.Interfaces.Specifications;

namespace DesignByContract.Domain.Core.Specifications
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> left,
                               ISpecification<T> right)
        {
            _leftSpecification = left;
            _rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) ||
                   _rightSpecification.IsSatisfiedBy(candidate);
        }
    }
}