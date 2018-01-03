using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.ValueObjects;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class SpecificationTests
    {
        [TestMethod]
        public void SpecificationNewIsSatisfiedByReturnTrue()
        {
            var valueObjectFakeForSpecification = new ValueObjectFakeForSpecification("Name");
            var sut = new ValueObjectFakeValidationForSpecification<ValueObjectFakeForSpecification>();
            Assert.IsTrue(sut.IsSatisfiedBy(valueObjectFakeForSpecification));
        }

        [TestMethod]
        public void SpecificationNewIsSatisfiedByReturnFalse()
        {
            var valueObjectFakeForSpecification = new ValueObjectFakeForSpecification("N");
            var sut = new ValueObjectFakeValidationForSpecification<ValueObjectFakeForSpecification>();
            Assert.IsFalse(sut.IsSatisfiedBy(valueObjectFakeForSpecification));
        }
    }
}