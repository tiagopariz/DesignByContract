namespace DesignByContract.Domain.Core.Interfaces.Errors
{
    public interface ILevel
    {
        string Description { get; }

        string ToString();
    }
}