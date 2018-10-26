using DesignByContract.Core.Domain.Entities;
using System;

namespace DesignByContract.Core.Tests.Application.Mocks.DomainFake.Entities
{
    public class EntityFake : Entity
    {
        public EntityFake(Guid id,
                          string fieldName = null)
            : base(id,
                   fieldName)
        {

        }
    }
}