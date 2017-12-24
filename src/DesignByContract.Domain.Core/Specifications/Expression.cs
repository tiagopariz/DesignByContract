using System;

namespace DesignByContract.Domain.Core.Specifications
{
    public class Expression<T> : Specification<T>
    {
        private readonly Func<T, bool> _expression;

        public Expression(Func<T, bool> expression)
        {
            _expression = expression;
        }

        public override bool IsSatisfiedBy(T candidate) =>
            _expression(candidate);
    }
}