using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExpressionWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> sut =
                new Expression<EntityFakeForSpecification>(x => x.Category == "Customer" &&
                                          x.City == "New York");
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York" }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> sut = 
                new Expression<EntityFakeForSpecification> (x => x.Category == "Customer" &&
                                           x.City == "New York");
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio" }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.And(livesInNewYork)
                                .And(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York", Active = true }));
        }

        [TestMethod]
        public void ExpressionWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.And(livesInNewYork)
                                .And(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio", Active = true }));
        }
    }
}