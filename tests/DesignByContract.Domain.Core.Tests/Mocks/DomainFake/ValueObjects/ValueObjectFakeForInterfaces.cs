using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.ValueObjects;
using DesignByContract.Domain.Core.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects
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