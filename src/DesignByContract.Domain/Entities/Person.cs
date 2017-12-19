using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Specifications.ValueObjects;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Entities
{
    public class Person : Entity
    {
        public Person(Guid id, PersonName name, Email email, bool isRequired = false) : base(id)
        {
            Name = name;
            Email = email;
            Validate(isRequired);
        }

        public sealed override void Validate(bool isRequired)
        {
            ValidSpecification = new PersonValidSpecification<object>(isRequired);
            ValidSpecification.IsSatisfiedBy(this);
        }

        public PersonName Name { get; }
        public Email Email { get; }
    }
}