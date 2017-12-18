namespace DesignByContract.Domain.Core.Interfaces.Notifications
{
    public interface IDescription
    {
        string Message { get; }

        string ToString();
    }
}