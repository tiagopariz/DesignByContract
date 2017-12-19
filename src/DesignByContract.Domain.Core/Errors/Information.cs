using DesignByContract.Domain.Core.Interfaces.Errors;

namespace DesignByContract.Domain.Core.Errors
{
    public class Information : ILevel
    {
        public Information(string description = "Information")
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