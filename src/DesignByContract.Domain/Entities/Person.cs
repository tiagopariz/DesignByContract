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

        public const string PersonNameFieldName = PersonValidSpecification<object>.PersonNameFieldName;
        public const string EmailFieldName = PersonValidSpecification<object>.EmailFieldName;
        public const string CategoryFieldName = PersonValidSpecification<object>.CategoryFieldName;
        public const string ManagerFieldName = PersonValidSpecification<object>.ManagerFieldName;

        #endregion

        public Person(Guid id,
                      PersonName name,
                      Email email,
                      Category category,
                      Person manager = null,
                      string fieldName = null) 
            : base(id, fieldName)
        {
            name?.SetFieldName(PersonNameFieldName);
            email?.SetFieldName(EmailFieldName);
            category?.SetFieldName(CategoryFieldName);
            manager?.SetFieldName(ManagerFieldName);

            Name = name;
            Email = email;
            Category = category;
            Manager = manager;
            
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