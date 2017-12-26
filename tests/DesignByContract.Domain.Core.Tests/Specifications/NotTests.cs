using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class NotTests
    {
        [TestMethod]
        public void NotWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.Not(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio" }));
        }

        [TestMethod]
        public void NotWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.Not(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York" }));
        }

        [TestMethod]
        public void NotWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.Not(livesInNewYork)
                                .Not(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio", Active = false }));
        }

        [TestMethod]
        public void NotWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.Not(livesInNewYork)
                                .And(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York", Active = true }));
        }
    }
}