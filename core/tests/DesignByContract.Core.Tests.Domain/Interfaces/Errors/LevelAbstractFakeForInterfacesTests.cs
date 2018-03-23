using DesignByContract.Core.Domain.Interfaces.Errors;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Interfaces.Errors
{
    [TestFixture]
    public abstract class LevelAbstractFakeForInterfacesTests
    {
        public abstract ILevel GetILevelInstance();

        [Test]
        public void LevelParseString()
        {
            var level = GetILevelInstance();
            Assert.IsTrue(!string.IsNullOrEmpty(level.Description));
        }

        [Test]
        public void LevelToString()
        {
            var level = GetILevelInstance();
            Assert.IsTrue(!string.IsNullOrEmpty(level.ToString()));
        }
    }
}