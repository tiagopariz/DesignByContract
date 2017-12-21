using DesignByContract.Domain.Core.Interfaces.Errors;
using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Errors
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