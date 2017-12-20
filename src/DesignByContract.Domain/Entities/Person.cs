using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Specifications.Entities;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Entities
{
    public class Person : Entity
    {
        #region Contract Terms

        public const bool NameRequired = PersonValidSpecification<object>.PersonNameRequired;
        public const bool EmailRequired = PersonValidSpecification<object>.PersonNameRequired;
        public const bool CategoryRequired = PersonValidSpecification<object>.CategoryRequired;
        public const bool ManagerRequired = PersonValidSpecification<object>.ManagerRequired;

        #endregion

        public Person(Guid id,
                      PersonName name,
                      Email email,
                      Category category,
                      Person manager = null,
                      string fieldName = null) 
            : base(id, fieldName)
        {

            Name = name;
            Email = email;
            Category = category;
            Manager = manager;

            Name?.SetFieldName(GetPropertyName(() => Name));
            Email?.SetFieldName(GetPropertyName(() => Email));
            Category?.SetFieldName(GetPropertyName(() => Category));
            Manager?.SetFieldName(GetPropertyName(() => Manager));

            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new PersonValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public PersonName Name { get; }
        public Email Email { get; }
        public Category Category { get; }
        public Person Manager { get; }
    }
}