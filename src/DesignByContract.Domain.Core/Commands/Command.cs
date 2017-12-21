using System.Collections.Generic;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Errors;

namespace DesignByContract.Domain.Core.Commands
{
    public abstract class Command
    {
        protected Command(Entity entity)
        {
            Entity = entity;
        }

        protected Entity Entity;
        //protected IList<ErrorDescription> Errors => Entity.Notification.Errors;
    }
}