using System;
using System.Runtime.CompilerServices;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        Error Notification { get; }
        CompositeSpecification<object> ValidSpecification { get; }
        string FieldName { get; }
        void Validate();
        //void Fail(bool condition, ErrorDescription error);
        bool IsValid();
    }
}