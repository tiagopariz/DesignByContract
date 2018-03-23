using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Contracts.Entities
{
    public class CategoryValidation<T> : Specification<T>
    {
        public const int DescriptionMinLength = 1;
        public const int DescriptionMaxLength = 30;
        public const bool DescriptionRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var category = candidate as Category;

            if (string.IsNullOrEmpty(category?.Description))
                category?.ErrorList.Add(
                    new ErrorItemDetail("{0} is required",
                                        new Critical(),
                                        "Description",
                                        "Description"));

            if ((category?.Description ?? "").Length < DescriptionMinLength)
                category?.ErrorList.Add(
                    new ErrorItemDetail("Descrição não atende o limite mínimo de caracteres",
                                        new Critical(),
                                        category.FieldName));

            if ((category?.Description ?? "").Length > DescriptionMaxLength)
                category?.ErrorList.Add(
                    new ErrorItemDetail("Descrição excedeu o limite máximo de caracteres",
                                        new Critical(),
                                        category.FieldName));

            return !category?.ErrorList.HasCriticals ?? false;
        }
    }
}