using System;
using DesignByContract.Domain.Core.Interfaces.Entities;

namespace DesignByContract.Domain.Core.Entities
{
    public abstract class Entity : IEntity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}