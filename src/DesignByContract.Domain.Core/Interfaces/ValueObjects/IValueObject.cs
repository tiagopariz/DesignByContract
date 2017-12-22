using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;

namespace DesignByContract.Domain.Core.Interfaces.ValueObjects
{
    public interface IValueObject
    {
        ErrorList ErrorList { get; }
        Specification<object> ValidSpecification { get; }
        string FieldName { get; }

        bool IsValid();
    }
}