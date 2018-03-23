using DesignByContract.Core.Domain.ValueObjects;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.ValueObjects;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects
{
    public class ValueObjectFakeForInterfaces : ValueObject
    {
        public ValueObjectFakeForInterfaces(string fieldname = "ValueObjectFakeForInterfaces") :
            base(fieldname)
        {
            ValidSpecification = new ValueObjectFakeValidationForInterfaces<object>();
        }
    }
}