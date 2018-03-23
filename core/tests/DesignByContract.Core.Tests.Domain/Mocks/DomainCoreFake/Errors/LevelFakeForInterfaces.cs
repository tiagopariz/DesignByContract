using DesignByContract.Core.Domain.Interfaces.Errors;

namespace DesignByContract.Core.Tests.Domain.Mocks.DomainCoreFake.Errors
{
    public class LevelFakeForInterfaces : ILevel
    {
        public LevelFakeForInterfaces(string description)
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString() => Description;
    }
}