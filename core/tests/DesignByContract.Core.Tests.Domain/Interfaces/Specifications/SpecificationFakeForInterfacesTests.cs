using DesignByContract.Core.Domain.Interfaces.Specifications;
using DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Specifications;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Specifications
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