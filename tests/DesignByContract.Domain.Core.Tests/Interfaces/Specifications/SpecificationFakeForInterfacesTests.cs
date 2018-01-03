using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Specifications
{
    [TestClass]
    public class SpecificationFakeForInterfacesTests : SpecificationAbstractFakeForInterfacesTests
    {
        public override ISpecification<object> GetISpecificationInstance()
        {
            return new SpecificationFakeForInterfaces<object>();
        }
    }
}