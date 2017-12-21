using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using System;

namespace DesignByContract.Domain.Core.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        ErrorList ErrorList { get; }
        CompositeSpecification<object> ValidSpecification { get; }
        string FieldName { get; }

        void Validate();
        bool IsValid();
    }
}