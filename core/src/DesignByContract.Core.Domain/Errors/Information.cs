using DesignByContract.Core.Domain.Interfaces.Errors;

namespace DesignByContract.Core.Domain.Errors
{
    public class Information : ILevel
    {
        public Information(string description = "Information")
        {
            Description = description;
        }

        public string Description { get; }

        public override string ToString() => Description;
    }
}