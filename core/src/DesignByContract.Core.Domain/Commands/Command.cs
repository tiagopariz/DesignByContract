using DesignByContract.Core.Domain.Interfaces.Commands;
using DesignByContract.Core.Domain.Interfaces.Entities;

namespace DesignByContract.Core.Domain.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(IEntity entity)
        {
            Entity = entity;
        }

        protected IEntity Entity;

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}