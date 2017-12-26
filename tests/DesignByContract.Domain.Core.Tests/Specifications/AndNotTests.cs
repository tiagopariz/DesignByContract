using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class AndNotTests
    {
        [TestMethod]
        public void AndNotWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.AndNot(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio" }));
        }

        public void AndNotWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            var sut = isCustomer.AndNot(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio" }));
        }

        [TestMethod]
        public void AndNotWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.AndNot(livesInNewYork)
                                .AndNot(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio", Active = false }));
        }

        [TestMethod]
        public void AndNotWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.AndNot(livesInNewYork)
                                .AndNot(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Partner", City = "Rio", Active = true }));
        }
    }
}