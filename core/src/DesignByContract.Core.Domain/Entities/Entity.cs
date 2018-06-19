using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Interfaces.Entities;
using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Interfaces.Specifications;
using System;
using System.Linq.Expressions;

namespace DesignByContract.Core.Domain.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id, string fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                fieldName = GetType().Name;
            if (id == Guid.Empty) id = Guid.NewGuid();

            Id = id;
            FieldName = fieldName;
        }

        public Guid Id { get; }
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

        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression)?.Member.Name ?? "";
        }
    }
}