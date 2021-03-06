﻿using DesignByContract.Core.Domain.Entities;
using DesignByContract.Domain.Contracts.Entities;
using DesignByContract.Domain.ValueObjects;
using System;

namespace DesignByContract.Domain.Entities
{
    public class Person : Entity
    {
        public const bool NameRequired = PersonValidation<object>.PersonNameRequired;
        public const bool EmailRequired = PersonValidation<object>.PersonNameRequired;
        public const bool CategoryRequired = PersonValidation<object>.CategoryRequired;
        public const bool ManagerRequired = PersonValidation<object>.ManagerRequired;

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

        private void Validate()
        {
            ValidSpecification = new PersonValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public PersonName Name { get; private set; }
        public Email Email { get; private set; }
        public Category Category { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public Person Manager { get; private set; }
    }
}