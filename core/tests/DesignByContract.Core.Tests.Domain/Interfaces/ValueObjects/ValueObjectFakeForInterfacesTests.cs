using DesignByContract.Core.Domain.Interfaces.ValueObjects;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.ValueObjects
{
    [TestFixture]
    public class ValueObjectFakeForInterfacesTests : ValueObjectAbstractFakeForInterfacesTests
    {
        public override IValueObject GetValueObjectInstance()
        {
            return new ValueObjectFakeForInterfaces();
        }
    }
}