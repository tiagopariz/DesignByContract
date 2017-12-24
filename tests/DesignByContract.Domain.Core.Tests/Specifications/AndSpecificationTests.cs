using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignByContract.Domain.Core.Tests.Specifications
{
    [TestClass]
    public class AndSpecificationTests
    {
        [TestMethod]
        public void AndSpecification_When_Filter_With_Two_Specifications()
        {
            var listFake = new List<Fake>()
            {
                new Fake { Id = 1, Name = "Name01", Category = "Customer", City = "Porto" },
                new Fake { Id = 2, Name = "Name02", Category = "Customer", City = "Porto" },
                new Fake { Id = 3, Name = "Name03", Category = "Customer", City = "Rio" },
            };

            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInPorto = new Expression<Fake>(x => x.City == "Porto");
            var sut = isCustomer.And(livesInPorto);

            var listFakeFiltered = listFake.FindAll(x => sut.IsSatisfiedBy(x));

            var result01 = listFakeFiltered[0].Name;
            var result02 = listFakeFiltered[1].Name;

            Assert.AreEqual(true, result01 == "Name01" && result02 == "Name02" && listFakeFiltered.Count == 2);
        }

        [TestMethod]
        public void AndSpecification_When_Filter_With_Many_Specifications()
        {
            var listFake = new List<Fake>()
            {
                new Fake { Id = 1, Name = "Name01", Category = "Customer", City = "New York", Active = true },
                new Fake { Id = 2, Name = "Name02", Category = "Customer", City = "New York", Active = false },
                new Fake { Id = 3, Name = "Name03", Category = "Customer", City = "Rio", Active = true },
                new Fake { Id = 4, Name = "Name04", Category = "Customer", City = "New York", Active = false },
                new Fake { Id = 5, Name = "Name05", Category = "Partner", City = "New York", Active = false },
                new Fake { Id = 6, Name = "Name06", Category = "Customer", City = "New York", Active = true },
            };

            ISpecification<Fake> isCustomer = new Expression<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInNewYork = new Expression<Fake>(x => x.City == "New York");
            ISpecification<Fake> isActive = new Expression<Fake>(x => x.Active);
            var sut = isCustomer.And(livesInNewYork)
                                .And(isActive);

            var listFakeFiltered = listFake.FindAll(x => sut.IsSatisfiedBy(x));

            var result01 = listFakeFiltered[0].Name;
            var result02 = listFakeFiltered[1].Name;

            Assert.AreEqual(true, result01 == "Name01" && result02 == "Name06" && listFakeFiltered.Count == 2);
        }
    }
}