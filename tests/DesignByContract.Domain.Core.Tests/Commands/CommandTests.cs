using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Commands;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;

namespace DesignByContract.Domain.Core.Tests.Commands
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void CommandNewWhenParseValidEntity()
        {
            var sut = new SaveEntityFake(new EntityFake(Guid.NewGuid(), new ValueObjectFake("Test")));
            sut.Run();
        }
    }
}