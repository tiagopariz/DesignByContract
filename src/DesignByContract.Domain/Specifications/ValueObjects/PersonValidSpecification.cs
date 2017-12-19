using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.Entities;

namespace DesignByContract.Domain.Specifications.ValueObjects
{
    public class PersonValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;

        public PersonValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            if (string.IsNullOrEmpty(person?.Name.ToString()) && !_required)
                return true;

            person?.Notification.Concat(person.Name.Notification,
                                        person.Email.Notification);

            return person?.Notification.HasErrors ?? false;
        }
    }
}