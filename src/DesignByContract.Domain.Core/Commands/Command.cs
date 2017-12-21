using DesignByContract.Domain.Core.Entities;

namespace DesignByContract.Domain.Core.Commands
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