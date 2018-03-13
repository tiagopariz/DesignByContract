using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using System;

namespace DesignByContract.Domain.Core.Interfaces.Entities
{
    public interface IEntity : IDisposable
    {
        Guid Id { get; }
        ErrorList ErrorList { get; }
        Specification<object> ValidSpecification { get; }
        string FieldName { get; }

        bool IsValid();
    }
}