using DesignByContract.Domain.Core.Interfaces.Errors;

namespace DesignByContract.Domain.Core.Errors
{
    public class Critical : ILevel
    {
        public Critical(string description = "Critical")
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString()
        {
            return Description;
        }
    }
}