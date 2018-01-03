using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Specifications
{
    public class SpecificationFakeForInterfaces<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T candidate) { return true; }

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