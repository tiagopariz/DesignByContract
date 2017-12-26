using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExpressionWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<Fake> sut =
                new Expression<Fake>(x => x.Category == "Customer" &&
                                          x.City == "New York");
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York" }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<Fake> sut = 
                new Expression<Fake> (x => x.Category == "Customer" &&
                                           x.City == "New York");
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio" }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.And(livesInNewYork)
                                .And(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "New York", Active = true }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.And(livesInNewYork)
                                .And(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new Fake { Category = "Customer", City = "Rio", Active = true }));
        }
    }
}