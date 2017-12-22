using DesignByContract.Domain.Core.Tests.FakeDomain.Contracts.ValueObjects;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class SpecificationTests
    {
        [TestMethod]
        public void Specification_New_IsSatisfiedBy_True()
        {
            var valueObjectFake = new ValueObjectFake("Name");
            var sut = new ValueObjectFakeValidation<ValueObjectFake>();
            Assert.AreEqual(true, sut.IsSatisfiedBy(valueObjectFake));
        }

        [TestMethod]
        public void Specification_New_IsSatisfiedBy_False()
        {
            var valueObjectFake = new ValueObjectFake("N");
            var sut = new ValueObjectFakeValidation<ValueObjectFake>();
            Assert.AreEqual(false, sut.IsSatisfiedBy(valueObjectFake));
        }
    }
}
