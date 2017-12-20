using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Specifications.Entities
{
    public class PersonValidSpecification<T> : CompositeSpecification<T>
    {
        public const bool PersonNameRequired = true;
        public const bool EmailRequired = true;
        public const bool CategoryRequired = true;
        public const bool ManagerRequired = false;

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            if (string.IsNullOrEmpty(person?.Name?.ToString()))
                person?.Notification.Add(new ErrorDescription("{0} is required", new Critical(), "Name", "Name"));

            if (string.IsNullOrEmpty(person?.Email?.ToString()))
                person?.Notification.Add(new ErrorDescription("{0} is required", new Critical(), "E-Mail", "E-Mail"));

            if (string.IsNullOrEmpty(person?.Category?.ToString()))
                person?.Notification.Add(new ErrorDescription("{0} is required", new Critical(), "Category", "Category"));

            person?.Notification.Concat(person.Name?.Notification,
                                        person.Email?.Notification,
                                        person.Category?.Notification,
                                        person.Manager?.Notification);

            return !person?.Notification.HasErrors ?? false;
        }
    }
}