using System;
using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Specifications.Entities;

namespace DesignByContract.Domain.Entities
{
    public class Category : Entity
    {
        public const int DescriptionMinLength = 1;
        public const int DescriptionMaxLength = 20;

        public Category(Guid id, string description, bool isRequired = false) : 
            base(id)
        {
            Description = description;
            Validate(isRequired);
        }

        public sealed override void Validate(bool isRequired)
        {
            ValidSpecification = new CategoryValidSpecification<object>(isRequired);
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Description { get; }
    }
}