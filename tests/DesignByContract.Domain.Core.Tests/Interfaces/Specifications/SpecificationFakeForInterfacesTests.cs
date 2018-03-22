using DesignByContract.Domain.Core.Interfaces.Specifications;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Specifications;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Specifications
{
    [TestFixture]
    public class SpecificationFakeForInterfacesTests : SpecificationAbstractFakeForInterfacesTests
    {
        public override ISpecification<object> GetISpecificationInstance()
        {
            return new SpecificationFakeForInterfaces<object>();
        }
    }
}