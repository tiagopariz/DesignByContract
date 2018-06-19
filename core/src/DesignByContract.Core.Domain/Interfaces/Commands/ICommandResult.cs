namespace DesignByContract.Core.Domain.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
    }
}