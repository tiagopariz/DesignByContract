using System;

namespace DesignByContract.Domain.Core.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}