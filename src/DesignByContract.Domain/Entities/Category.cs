using DesignByContract.Domain.Core.Entities;
using System;
using DesignByContract.Domain.Contracts.Entities;

namespace DesignByContract.Domain.Entities
{
    public class Category : Entity
    {
        public const int DescriptionMinLength = CategoryValidation<object>.DescriptionMinLength;
        public const int DescriptionMaxLength = CategoryValidation<object>.DescriptionMaxLength;
        public const bool DescriptionRequired = CategoryValidation<object>.DescriptionRequired;

        public Category(Guid id,
                        string description,
                        string fieldName = null)
            : base(id, fieldName)
        {
            Description = description;

            Validate();
        }

        private void Validate()
        {
            ValidSpecification = new CategoryValidation<object>();
            ValidSpecification.IsSatisfiedBy(this);
        }

        public string Description { get; }
    }
}