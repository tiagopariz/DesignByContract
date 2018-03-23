using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using System;

namespace DesignByContract.Core.Domain.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        ErrorList ErrorList { get; }
        Specification<object> ValidSpecification { get; }
        string FieldName { get; }

        bool IsValid();
    }
}