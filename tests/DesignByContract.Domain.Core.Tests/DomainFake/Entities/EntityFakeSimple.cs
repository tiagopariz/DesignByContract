using System;
using DesignByContract.Domain.Core.Entities;

namespace DesignByContract.Domain.Core.Tests.DomainFake.Entities
{
    public class EntitySimpleFake : Entity
    {
        public EntitySimpleFake(Guid id) : 
            base(id)
        {
        }
    }
}