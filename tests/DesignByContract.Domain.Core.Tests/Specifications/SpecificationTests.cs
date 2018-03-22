using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Contracts.ValueObjects;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Specifications
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