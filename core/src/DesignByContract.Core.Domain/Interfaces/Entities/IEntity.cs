using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Interfaces.Specifications;
using System;

namespace DesignByContract.Core.Domain.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        IErrorList ErrorList { get; }
        ISpecification<object> ValidSpecification { get; }
        string FieldName { get; }
        bool IsValid();
    }
}