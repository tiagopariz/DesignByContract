using DesignByContract.Domain.Core.Interfaces.Errors;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Errors;
using NUnit.Framework;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Errors
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