using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class OrNotTests
    {
        [TestMethod]
        public void OrNotWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.OrNot(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio" }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.OrNot(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio" }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.OrNot(livesInNewYork)
                                .OrNot(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio", Active = false }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.OrNot(livesInNewYork)
                                .OrNot(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio", Active = true }));
        }
    }
}