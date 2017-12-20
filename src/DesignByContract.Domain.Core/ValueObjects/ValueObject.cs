using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.ValueObjects
{
    public abstract class ValueObject : IValueObject
    {
        public Error Notification { get; } = new Error();
        public CompositeSpecification<object> ValidSpecification { get; set; } = null;
        public string FieldName => GetType().Name;

        public virtual void Validate(bool isRequired) { }

        public bool IsValid()
        {
            return !Notification.HasErrors;
        }
    }
}