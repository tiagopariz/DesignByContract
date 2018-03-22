using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.ValueObjects
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