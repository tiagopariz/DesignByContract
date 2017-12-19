using DesignByContract.Domain.Core.Interfaces.Errors;
using DesignByContract.Domain.Core.Notifications;

namespace DesignByContract.Domain.Core.Errors
{
    public class ErrorDescription : Description
    {
        public ILevel Level { get; }

        public ErrorDescription(string message, ILevel level, params string[] args)
            : base(message, args)
        {
            Level = level;
        }
    }
}