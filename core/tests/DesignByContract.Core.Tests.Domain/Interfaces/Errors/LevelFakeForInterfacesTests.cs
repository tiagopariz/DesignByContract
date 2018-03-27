using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Tests.Domain.Mocks.CoreDomainFake.Errors;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Errors
{
    [TestFixture]
    public class LevelFakeForInterfacesTests : LevelAbstractFakeForInterfacesTests
    {
        public override ILevel GetILevelInstance()
        {
            return new LevelFakeForInterfaces("Tests");
        }
    }
}