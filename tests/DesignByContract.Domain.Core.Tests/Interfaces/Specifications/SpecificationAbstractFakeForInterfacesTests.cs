using DesignByContract.Domain.Core.Interfaces.Specifications;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Specifications
{
    [TestFixture]
    public abstract class SpecificationAbstractFakeForInterfacesTests
    {
        public abstract ISpecification<object> GetISpecificationInstance();

        [Test]
        public void SpecificationParseObjectReturnIsSatisfiedByTrue()
        {
            var specification = GetISpecificationInstance();
            Assert.IsTrue(specification.IsSatisfiedBy(new object()));
        }

        [Test]
        public void SpecificationAndReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.And(specification2);
            Assert.IsTrue(specification3.IsSatisfiedBy(new object()));
        }

        [Test]
        public void SpecificationAndNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.AndNot(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }

        [Test]
        public void SpecificationOrReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.Or(specification2);
            Assert.IsTrue(specification3.IsSatisfiedBy(new object()));
        }

        [Test]
        public void SpecificationOrNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.OrNot(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }

        [Test]
        public void SpecificationNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.Not(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }
    }
}