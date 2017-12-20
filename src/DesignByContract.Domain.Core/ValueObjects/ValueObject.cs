using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.ValueObjects
{
    public abstract class ValueObject : IValueObject
    {
        protected ValueObject(string fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                fieldName = GetType().Name;

            FieldName = fieldName;
        }

        public Error Notification { get; } = new Error();
        public CompositeSpecification<object> ValidSpecification { get; set; } = null;
        public string FieldName { get; private set; }

        public void SetFieldName(string value)
        {
            FieldName = value;
        }

        public virtual void Validate() { }

        public bool IsValid()
        {
            return !Notification.HasErrors;
        }
    }
}