using DesignByContract.Core.Domain.Interfaces.Errors;
using DesignByContract.Core.Domain.Notifications;

namespace DesignByContract.Core.Domain.Errors
{
    public class ErrorItemDetail : ItemDetail
    {
        public ILevel Level { get; }
        public string FieldName { get; }

        public ErrorItemDetail(string message,
                               ILevel level,
                               string fieldName,
                               params string[] args)
            : base(message, args)
        {
            Level = level;
            FieldName = fieldName;
        }
    }
}