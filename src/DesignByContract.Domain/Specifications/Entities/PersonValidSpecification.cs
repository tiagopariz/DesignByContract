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

        public const string PersonNameFieldName = "Nome da pessoa";
        public const string EmailFieldName = "E-Mail";
        public const string CategoryFieldName = "Categoria";
        public const string ManagerFieldName = "Gerente";

        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            if (string.IsNullOrEmpty(person?.Name?.ToString()))
                person?.Notification.Add(new ErrorDescription("O nome é requerido", new Critical(), PersonNameFieldName));

            if (string.IsNullOrEmpty(person?.Email?.ToString()))
                person?.Notification.Add(new ErrorDescription("O E-Mail é requerido", new Critical(), EmailFieldName));

            if (string.IsNullOrEmpty(person?.Category?.ToString()))
                person?.Notification.Add(new ErrorDescription("A Categoria é requerida", new Critical(), CategoryFieldName));

            person?.Notification.Concat(person.Name?.Notification,
                                        person.Email?.Notification,
                                        person.Category?.Notification,
                                        person.Manager?.Notification);

            return !person?.Notification.HasErrors ?? false;
        }
    }
}