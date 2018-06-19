using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Interfaces.Specifications;

namespace DesignByContract.Core.Domain.Interfaces.ValueObjects
{
    public interface IValueObject
    {
        IErrorList ErrorList { get; }
        ISpecification<object> ValidSpecification { get; }
        string FieldName { get; }
        bool IsValid();
    }
}