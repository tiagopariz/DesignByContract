using DesignByContract.Domain.Core.Interfaces.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Specifications
{
    [TestClass]
    public abstract class SpecificationAbstractFakeForInterfacesTests
    {
        public abstract ISpecification<object> GetISpecificationInstance();

        [TestMethod]
        public void SpecificationParseObjectReturnIsSatisfiedByTrue()
        {
            var specification = GetISpecificationInstance();
            Assert.IsTrue(specification.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void SpecificationAndReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.And(specification2);
            Assert.IsTrue(specification3.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void SpecificationAndNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.AndNot(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void SpecificationOrReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.Or(specification2);
            Assert.IsTrue(specification3.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void SpecificationOrNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.OrNot(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }

        [TestMethod]
        public void SpecificationNotReturnIsSatisfiedByTrue()
        {
            var specification1 = GetISpecificationInstance();
            var specification2 = GetISpecificationInstance();
            var specification3 = specification1.Not(specification2);
            Assert.IsTrue(!specification3.IsSatisfiedBy(new object()));
        }
    }
}