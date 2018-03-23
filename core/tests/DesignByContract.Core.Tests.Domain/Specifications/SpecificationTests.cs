using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Contracts.ValueObjects;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Specifications
{
    [TestFixture]
    public class SpecificationTests
    {
        [Test]
        public void SpecificationNewIsSatisfiedByReturnTrue()
        {
            var valueObjectFakeForSpecification = new ValueObjectFakeForSpecification("Name");
            var sut = new ValueObjectFakeValidationForSpecification<ValueObjectFakeForSpecification>();
            Assert.IsTrue(sut.IsSatisfiedBy(valueObjectFakeForSpecification));
        }

        [Test]
        public void SpecificationNewIsSatisfiedByReturnFalse()
        {
            var valueObjectFakeForSpecification = new ValueObjectFakeForSpecification("N");
            var sut = new ValueObjectFakeValidationForSpecification<ValueObjectFakeForSpecification>();
            Assert.IsFalse(sut.IsSatisfiedBy(valueObjectFakeForSpecification));
        }
    }
}