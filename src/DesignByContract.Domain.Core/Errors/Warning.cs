﻿using DesignByContract.Domain.Core.Interfaces.Errors;

namespace DesignByContract.Domain.Core.Errors
{
    public class Warning : ILevel
    {
        public Warning(string description = "Warning")
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