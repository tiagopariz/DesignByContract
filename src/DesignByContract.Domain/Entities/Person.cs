using System;
using DesignByContract.Domain.Core.Entities;

namespace DesignByContract.Domain.Entities
{
    public class Person : Entity
    {
        public Person(Guid id) : base(id) { }
    }
}