using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Interfaces.ValueObjects;
using DesignByContract.Core.Domain.Specifications;

namespace DesignByContract.Core.Domain.ValueObjects
{
    public abstract class ValueObject : IValueObject
    {
        protected ValueObject(string fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                fieldName = GetType().Name;

            FieldName = fieldName;
        }

        public ErrorList ErrorList { get; } = new ErrorList();
        public Specification<object> ValidSpecification { get; set; } = null;
        public string FieldName { get; private set; }

        public void SetFieldName(string value)
        {
            FieldName = value;
        }

        public bool IsValid()
        {
            return !ErrorList.HasCriticals;
        }
    }
}