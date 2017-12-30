using DesignByContract.Domain.Core.Interfaces.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.Errors
{
    [TestClass]
    public abstract class AbstractLevelFakeForInterfacesTests
    {
        public abstract ILevel GetILevelInstance();

        [TestMethod]
        public void LevelParseString()
        {
            var level = GetILevelInstance();
            Assert.IsTrue(!string.IsNullOrEmpty(level.Description));
        }

        [TestMethod]
        public void LevelToString()
        {
            var level = GetILevelInstance();
            Assert.IsTrue(!string.IsNullOrEmpty(level.ToString()));
        }
    }
}