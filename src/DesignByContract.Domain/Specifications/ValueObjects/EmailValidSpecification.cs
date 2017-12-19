using System.Text.RegularExpressions;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Specifications;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Specifications.ValueObjects
{
    public class EmailValidSpecification<T> : CompositeSpecification<T>
    {
        private readonly bool _required;
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;

        public EmailValidSpecification(bool required = false)
        {
            _required = required;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            var email = candidate as Email;
            email?.Notification.List.Clear();

            if (string.IsNullOrEmpty(email?.Address) && !_required)
                return true;

            if ((email?.Address ?? "").Length < AddressMinLength)
                email?.Notification.Add(new ErrorDescription("Email não atende o limite mínimo de caracteres", new Critical()));

            if ((email?.Address ?? "").Length > AddressMaxLength)
                email?.Notification.Add(new ErrorDescription("Email excedeu o limite máximo de caracteres", new Critical()));

            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            if (!Regex.IsMatch(email?.Address ?? "", pattern))
                email?.Notification.Add(new ErrorDescription("Formato de e-mail inválido", new Critical()));

            return email?.Notification.HasErrors ?? false;
        }
    }
}