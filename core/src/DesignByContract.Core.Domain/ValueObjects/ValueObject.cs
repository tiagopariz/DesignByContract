using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Interfaces.Specifications;
using DesignByContract.Core.Domain.Interfaces.ValueObjects;

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

        public IErrorList ErrorList { get; } = new ErrorList();
        public ISpecification<object> ValidSpecification { get; set; } = null;
        public string FieldName { get; private set; }

        public void SetFieldName(string value)
        {
            FieldName = value;
        }

        public bool IsValid()
        {
            return !ErrorList.HasCriticals();
        }
    }
}