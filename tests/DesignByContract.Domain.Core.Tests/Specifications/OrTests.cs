using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class OrTests
    {
        [TestMethod]
        public void OrWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.Or(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York" }));
        }

        [TestMethod]
        public void OrWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.Or(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio"}));
        }

        [TestMethod]
        public void OrWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.Or(livesInNewYork)
                                .Or(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York", Active = true }));
        }

        [TestMethod]
        public void OrWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.Or(livesInNewYork)
                                .Or(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio", Active = false }));
        }
    }
}