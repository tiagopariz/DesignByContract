using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Interfaces.ValueObjects
{
    public interface IValueObject
    {
        Error Notification { get; }
        CompositeSpecification<object> ValidSpecification { get; }
        string FieldName { get; }
        void Validate(bool isRequired);
        //void Fail(bool condition, ErrorDescription error);
        bool IsValid();
    }
}