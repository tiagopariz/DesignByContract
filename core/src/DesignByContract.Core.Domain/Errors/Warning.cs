using DesignByContract.Core.Domain.Interfaces.Errors;

namespace DesignByContract.Core.Domain.Errors
{
    public class Warning : ILevel
    {
        public Warning(string description = "Warning")
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString() => Description;
    }
}