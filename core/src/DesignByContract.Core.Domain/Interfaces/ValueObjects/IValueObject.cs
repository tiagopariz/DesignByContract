using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;

namespace DesignByContract.Core.Domain.Interfaces.ValueObjects
{
    public interface IValueObject
    {
        ErrorList ErrorList { get; }
        Specification<object> ValidSpecification { get; }
        string FieldName { get; }

        bool IsValid();
    }
}