using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Commands;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;
using System;

namespace DesignByContract.Domain.Core.Tests.Commands
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void CommandNewWhenParseValidEntity()
        {
            var sut = new SaveEntityFake(new EntityFake(Guid.NewGuid(), new ValueObjectFake("Test")));
            sut.Run();
        }
    }
}