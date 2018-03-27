using DesignByContract.Core.Domain.Commands;
using DesignByContract.Core.Tests.Application.Mocks.DomainFake.Entities;

namespace DesignByContract.Core.Tests.Application.Mocks.DomainFake.Commands
{
    public class SaveEntityFake : Command
    {
        private readonly EntityFake _entityFake;

        public SaveEntityFake(EntityFake entityFake)
            : base(entityFake)
        {

        }

        public void Run() { }
    }
}