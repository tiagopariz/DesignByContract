using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Contracts.Entities
{
    public class PersonValidation<T> : Specification<T>
    {
        public const bool PersonNameRequired = true;
        public const bool EmailRequired = true;
        public const bool CategoryRequired = true;
        public const bool ManagerRequired = false;

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            if (string.IsNullOrEmpty(person?.Name?.ToString()))
                person?.ErrorList.Add(
                    new ErrorItemDetail("{0} is required",
                                        new Critical(),
                                        "Name",
                                        "Name"));

            if (string.IsNullOrEmpty(person?.Email?.ToString()))
                person?.ErrorList.Add(
                    new ErrorItemDetail("{0} is required",
                                        new Critical(),
                                        "E-Mail",
                                        "E-Mail"));

            if (string.IsNullOrEmpty(person?.Category?.ToString()))
                person?.ErrorList.Add(
                    new ErrorItemDetail("{0} is required",
                                        new Critical(),
                                        "Category",
                                        "Category"));

            person?.ErrorList.Concat(person.Name?.ErrorList,
                                        person.Email?.ErrorList,
                                        person.Category?.ErrorList,
                                        person.Manager?.ErrorList);

            return !person?.ErrorList.HasCriticals ?? false;
        }
    }
}