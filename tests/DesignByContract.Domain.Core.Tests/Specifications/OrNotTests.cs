using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class OrNotTests
    {
        [TestMethod]
        public void OrNotWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.OrNot(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Partner", City = "Rio" }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.OrNot(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio" }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.OrNot(livesInNewYork)
                                .OrNot(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio", Active = false }));
        }

        [TestMethod]
        public void OrNotWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.OrNot(livesInNewYork)
                                .OrNot(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Partner", City = "Rio", Active = true }));
        }
    }
}