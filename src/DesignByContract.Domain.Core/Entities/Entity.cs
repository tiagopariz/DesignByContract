using System;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.Entities;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id, string fieldName = null)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) fieldName = GetType().Name;
            if (id == Guid.Empty) id = Guid.NewGuid();

            Id = id;
            FieldName = fieldName;
        }

        public Guid Id { get; }
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