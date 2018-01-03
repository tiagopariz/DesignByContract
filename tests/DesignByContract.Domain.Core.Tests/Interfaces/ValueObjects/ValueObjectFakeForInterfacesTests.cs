using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.ValueObjects
{
    [TestClass]
    public class ValueObjectFakeForInterfacesTests : ValueObjectAbstractFakeForInterfacesTests
    {
        public override IValueObject GetValueObjectInstance()
        {
            return new ValueObjectFakeForInterfaces();
        }
    }
}