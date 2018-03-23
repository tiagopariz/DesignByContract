using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Commands;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.Entities;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;
using System;

namespace DesignByContract.Core.Tests.Domain.Commands
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