using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using System;

namespace DesignByContract.Domain.Core.Interfaces.ValueObjects
{
    public interface IValueObject : IDisposable
    {
        ErrorList ErrorList { get; }
        Specification<object> ValidSpecification { get; }
        string FieldName { get; }

        bool IsValid();
    }
}