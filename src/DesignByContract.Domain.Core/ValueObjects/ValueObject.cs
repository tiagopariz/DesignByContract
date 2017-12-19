using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.ValueObjects
{
    public abstract class ValueObject : IValueObject
    {
        public Error Notification { get; } = new Error();
        protected CompositeSpecification<object> ValidSpecification = null;

        public virtual void Validate() { }

        protected void Fail(bool condition, ErrorDescription error)
        {
            if (condition)
                Notification.Add(error);
        }

        public bool IsValid()
        {
            return ValidSpecification?.IsSatisfiedBy(this) ?? true;
        }
    }
}