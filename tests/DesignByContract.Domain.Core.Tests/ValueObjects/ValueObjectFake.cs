using DesignByContract.Domain.Core.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.ValueObjects
{
    public class ValueObjectFake : ValueObject
    {
        public ValueObjectFake(string fieldName)
            : base(fieldName)
        {
            
        }
    }
}
