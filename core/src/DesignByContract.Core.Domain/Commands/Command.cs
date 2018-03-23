using DesignByContract.Core.Domain.Entities;

namespace DesignByContract.Core.Domain.Commands
{
    public abstract class Command
    {
        protected Command(Entity entity)
        {
            Entity = entity;
        }

        protected Entity Entity;
    }
}