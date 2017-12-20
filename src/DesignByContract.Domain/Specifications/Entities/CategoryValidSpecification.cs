﻿using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Specifications.Entities
{
    public class CategoryValidSpecification<T> : CompositeSpecification<T>
    {
        public const int DescriptionMinLength = 1;
        public const int DescriptionMaxLength = 30;
        public const bool DescriptionRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var category = candidate as Category;

            if (string.IsNullOrEmpty(category?.Description))
                category?.Notification.Add(new ErrorDescription("{0} is required", new Critical(), "Description", "Description"));               

            if ((category?.Description ?? "").Length < DescriptionMinLength)
                category?.Notification.Add(new ErrorDescription("Descrição não atende o limite mínimo de caracteres", new Critical(), category.FieldName));

            if ((category?.Description ?? "").Length > DescriptionMaxLength)
                category?.Notification.Add(new ErrorDescription("Descrição excedeu o limite máximo de caracteres", new Critical(), category.FieldName));

            return !category?.Notification.HasErrors ?? false;
        }
    }
}