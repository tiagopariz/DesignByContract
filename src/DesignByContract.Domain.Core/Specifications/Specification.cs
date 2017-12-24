using DesignByContract.Domain.Core.Interfaces.Specifications;

namespace DesignByContract.Domain.Core.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);
        public ISpecification<T> And(ISpecification<T> specification) =>
            new And<T>(this, specification);
        public ISpecification<T> AndNot(ISpecification<T> specification) =>
            new AndNot<T>(this, specification);
        public ISpecification<T> Or(ISpecification<T> specification) =>
            new Or<T>(this, specification);
        public ISpecification<T> OrNot(ISpecification<T> specification) =>
            new OrNot<T>(this, specification);
        public ISpecification<T> Not(ISpecification<T> specification) =>
            new Not<T>(specification);
    }
}