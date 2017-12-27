using DesignByContract.Domain.Core.Commands;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Tests.DomainFake.Entities;

namespace DesignByContract.Domain.Core.Tests.DomainFake.Commands
{
    public class SaveEntityFake : Command
    {
        private readonly EntityFake _entityFake;

        public SaveEntityFake(EntityFake entityFake)
            : base(entityFake)
        {
            _entityFake = entityFake;
            var errorDescription = 
                new ErrorItemDetail("New EntityFake instance create on memory.", 
                                    new Warning(),
                                    "EntityFake");
            _entityFake.ErrorList.Add(errorDescription);
        }

        public void Run()
        {
            if (!_entityFake.ErrorList.HasCriticals)
            {
                SaveEntityFakeInBackendSystems();
            }
            else
            {
                var errorDescription = 
                    new ErrorItemDetail("Registration not saved.",
                                        new Critical(),
                                        "EntityFake");
                _entityFake.ErrorList.Add(errorDescription);
            }
        }

        private void SaveEntityFakeInBackendSystems()
        {
            var errorDescription = 
                new ErrorItemDetail("Registration succeeded.",
                                    new Information(),
                                    "EntityFake");
            _entityFake.ErrorList.Add(errorDescription);
        }
    }
}