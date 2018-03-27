using DesignByContract.Core.Application.Services;
using DesignByContract.Core.Tests.Application.Mocks.DomainFake.Commands;
using DesignByContract.Core.Tests.Application.Mocks.DomainFake.Entities;

namespace DesignByContract.Core.Tests.Application.Mocks.ApplicationFake.Services.Entities
{
    public class EntityFakeService : Service
    {
        private readonly EntityFake _entity;

        public EntityFakeService(EntityFake entity)
        {
            _entity = entity;
        }

        public void SaveEntityFake()
        {
            var cmd = new SaveEntityFake(_entity);
            cmd.Run();
        }
    }
}