using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Specifications.Entities;
using System;

namespace DesignByContract.Domain.Entities
{
    public class Category : Entity
    {
        public const int DescriptionMinLength = CategoryValidSpecification<object>.DescriptionMinLength;
        public const int DescriptionMaxLength = CategoryValidSpecification<object>.DescriptionMaxLength;
        public const bool DescriptionRequired = CategoryValidSpecification<object>.DescriptionRequired;

        public Category(Guid id,
                        string description,
                        string fieldName = null)
            : base(id, fieldName)
        {
            Description = description;

            Validate();
        }

        public sealed override void Validate()
        {
            ValidSpecification = new CategoryValidSpecification<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Description { get; }
    }
}