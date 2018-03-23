using DesignByContract.Core.Domain.Interfaces.Specifications;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Specifications
{
    [TestFixture]
    public class NotTests
    {
        [Test]
        public void NotWhenFilterWithTwoSpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.Not(livesInNewYork);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio" }));
        }

        [Test]
        public void NotWhenFilterWithTwoSpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            var sut = isCustomer.Not(livesInNewYork);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York" }));
        }

        [Test]
        public void NotWhenFilterWithManySpecificationsReturnTrue()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.Not(livesInNewYork)
                                .Not(isActive);
            Assert.IsTrue(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "Rio", Active = false }));
        }

        [Test]
        public void NotWhenFilterWithManySpecificationsReturnFalse()
        {
            ISpecification<EntityFakeForSpecification> isCustomer = new Expression<EntityFakeForSpecification>(x => x.Category == "Customer");
            ISpecification<EntityFakeForSpecification> livesInNewYork = new Expression<EntityFakeForSpecification>(x => x.City == "New York");
            ISpecification<EntityFakeForSpecification> isActive = new Expression<EntityFakeForSpecification>(x => x.Active);
            var sut = isCustomer.Not(livesInNewYork)
                                .And(isActive);
            Assert.IsFalse(sut.IsSatisfiedBy(new EntityFakeForSpecification { Category = "Customer", City = "New York", Active = true }));
        }
    }
}