using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Domain.Specifications;
using DesignByContract.Domain.ValueObjects;

namespace DesignByContract.Domain.Contracts.ValueObjects
{
    public class PersonNameValidation<T> : Specification<T>
    {
        public const int NameMinLength = 1;
        public const int NameMaxLength = 255;
        public const bool NameRequired = true;

        public override bool IsSatisfiedBy(T candidate)
        {
            var personName = candidate as PersonName;

            if (string.IsNullOrEmpty(personName?.Name))
                personName?.ErrorList.Add(
                    new ErrorItemDetail("O Nome é requerido",
                                        new Critical(),
                                        personName.FieldName));

            if ((personName?.Name ?? "").Length < NameMinLength)
                personName?.ErrorList.Add(
                    new ErrorItemDetail("Nome não atende o limite mínimo de caracteres",
                                        new Critical(),
                                        personName.FieldName));

            if ((personName?.Name ?? "").Length > NameMaxLength)
                personName?.ErrorList.Add(
                    new ErrorItemDetail("Nome excedeu o limite máximo de caracteres",
                                        new Critical(),
                                        personName.FieldName));

            return !personName?.ErrorList.HasCriticals ?? false;
        }
    }
}