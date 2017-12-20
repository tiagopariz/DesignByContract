using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Specifications.Entities;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Entities
{
    public class Person : Entity
    {
        public Person(Guid id,
                      PersonName name,
                      Email email,
                      Category category,
                      bool isRequired = false) 
            : base(id)
        {
            Name = name;
            Email = email;
            Category = category;
            Validate(isRequired);
        }

        public sealed override void Validate(bool isRequired)
        {
            ValidSpecification = new PersonValidSpecification<object>(isRequired);
            ValidSpecification.IsSatisfiedBy(this);
        }

        public PersonName Name { get; }
        public Email Email { get; }
        public Category Category { get; }
    }
}