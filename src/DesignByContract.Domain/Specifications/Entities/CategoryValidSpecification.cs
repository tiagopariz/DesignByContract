using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Specifications.Entities
{
    public class CategoryValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;
        public const int DescriptionMinLength = 1;
        public const int DescriptionMaxLength = 30;

        public CategoryValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var category = candidate as Category;

            if (string.IsNullOrEmpty(category?.Description) && !_required)
                return true;

            if ((category?.Description ?? "").Length < DescriptionMinLength)
                category?.Notification.Add(new ErrorDescription("Descrição não atende o limite mínimo de caracteres", new Critical()));

            if ((category?.Description ?? "").Length > DescriptionMaxLength)
                category?.Notification.Add(new ErrorDescription("Descrição excedeu o limite máximo de caracteres", new Critical()));

            return true;
        }
    }
}