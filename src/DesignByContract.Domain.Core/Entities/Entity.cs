using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.Entities;
using DesignByContract.Domain.Core.Specifications;
using System;
using System.Linq.Expressions;

namespace DesignByContract.Domain.Core.Entities
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

        public static string GetPropertyName<T>(System.Linq.Expressions.Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression)?.Member.Name ?? "";
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}