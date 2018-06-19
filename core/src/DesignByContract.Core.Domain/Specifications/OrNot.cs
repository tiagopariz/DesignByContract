using DesignByContract.Core.Domain.Interfaces.Specifications;

namespace DesignByContract.Core.Domain.Specifications
{
    public class OrNot<T> : Specification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public OrNot(ISpecification<T> left,
                     ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            (_left.IsSatisfiedBy(candidate) ||
             _right.IsSatisfiedBy(candidate)) != true;
    }
}