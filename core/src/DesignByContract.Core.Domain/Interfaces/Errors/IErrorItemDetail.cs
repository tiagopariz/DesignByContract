using DesignByContract.Core.Domain.Interfaces.Notifications;

namespace DesignByContract.Core.Domain.Interfaces.Errors
{
    public interface IErrorItemDetail : IItemDetail
    {
        ILevel Level { get; }
        string FieldName { get; }
    }
}