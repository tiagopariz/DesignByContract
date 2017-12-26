using DesignByContract.Domain.Core.Tests.FakeDomain.Contracts.ValueObjects;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class SpecificationTests
    {
        [TestMethod]
        public void SpecificationNewIsSatisfiedByReturnTrue()
        {
            var valueObjectFake = new ValueObjectFake("Name");
            var sut = new ValueObjectFakeValidation<ValueObjectFake>();
            Assert.IsTrue(sut.IsSatisfiedBy(valueObjectFake));
        }

        [TestMethod]
        public void SpecificationNewIsSatisfiedByReturnFalse()
        {
            var valueObjectFake = new ValueObjectFake("N");
            var sut = new ValueObjectFakeValidation<ValueObjectFake>();
            Assert.IsFalse(sut.IsSatisfiedBy(valueObjectFake));
        }
    }
}
