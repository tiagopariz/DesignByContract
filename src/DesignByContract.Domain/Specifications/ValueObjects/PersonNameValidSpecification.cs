using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Specifications.ValueObjects
{
    public class PersonNameValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;
        public const int NameMinLength = 1;
        public const int NameMaxLength = 255;

        public PersonNameValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var personName = candidate as PersonName;

            if (string.IsNullOrEmpty(personName?.Name) && !_required)
                return true;

            if ((personName?.Name ?? "").Length < NameMinLength)
                personName?.Notification.Add(new ErrorDescription("Nome não atende o limite mínimo de caracteres", new Critical()));

            if ((personName?.Name ?? "").Length > NameMaxLength)
                personName?.Notification.Add(new ErrorDescription("Nome excedeu o limite máximo de caracteres", new Critical()));

            return true;
        }
    }
}