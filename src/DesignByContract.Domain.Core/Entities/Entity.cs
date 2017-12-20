using System;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.Entities;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id)
        {
            if (id == Guid.Empty) id = Guid.NewGuid();
            Id = id;
        }

        public Guid Id { get; }
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