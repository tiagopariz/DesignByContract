using System;
using DesignByContract.Domain.Core.Entities;

namespace DesignByContract.Domain.Core.Tests.DomainFake.Entities
{
    public class EntityFakeForInterfaces : Entity
    {
        public EntityFakeForInterfaces(Guid id) : 
            base(id)
        {
        }
    }
}