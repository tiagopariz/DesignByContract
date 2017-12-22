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

            ISpecification<Fake> isCustomer = new ExpressionSpecification<Fake>(x => x.Category == "Customer");
            ISpecification<Fake> livesInPorto = new ExpressionSpecification<Fake>(x => x.City == "Porto");
            var sut = isCustomer.And(livesInPorto);

            var listFakeFiltered = listFake.FindAll(x => sut.IsSatisfiedBy(x));

            var result01 = listFakeFiltered[0].Name;
            var result02 = listFakeFiltered[1].Name;

            Assert.AreEqual(true, result01 == "Name01" && result02 == "Name02" && listFakeFiltered.Count == 2);
        }
    }
}