using DesignByContract.Domain.Core.Interfaces.Errors;
using DesignByContract.Domain.Core.Tests.Mocks.DomainCoreFake.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Errors
{
    [TestClass]
    public class LevelFakeForInterfacesTests : AbstractLevelFakeForInterfacesTests
    {
        public override ILevel GetILevelInstance()
        {
            return new LevelFakeForInterfaces("Tests");
        }
    }
}