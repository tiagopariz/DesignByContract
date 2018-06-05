using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Core.Tests.Domain.Errors
{
    [TestFixture]
    public class ErrorListTests
    {
        [Test]
        public void ErrorListNewInvalidErrorListNotNull()
        {
            var valueObjectFake = new ValueObjectFake("N");
            Assert.IsTrue(valueObjectFake.ErrorList != null);
        }

        [Test]
        public void ErrorListNewInvalidErrorListAnyReturnTrue()
        {
            var valueObjectFake = new ValueObjectFake("N");
            Assert.IsTrue(valueObjectFake.ErrorList.Any);
        }

        [Test]
        public void ErrorListNewValidErrorListAnyReturnFalse()
        {
            var valueObjectFake = new ValueObjectFake("Name");
            Assert.IsFalse(valueObjectFake.ErrorList.Any);
        }

        [Test]
        public void ErrorListNewInvalidErrorListIncludeReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorListIncludeReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorListAddReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorListAddReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var requiredWarning = new ErrorItemDetail("The Name is required.", new Warning(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredWarning);
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorListAddWithArgsReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The {0} is required.", new Critical(), "", "Name");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorListAddWithArgsReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The {0} is required.", new Critical(), "", "Name");
            var requiredWarning = new ErrorItemDetail("The {0} is required.", new Warning(), "", "Name");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredWarning);
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [Test]
        public void ErrorListNewInvalidErrorConcatSuccess()
        {
            var requiredWarning = new ErrorItemDetail("The Name is required.", new Warning(), "");
            var valueObjectFake1 = new ValueObjectFake("");
            valueObjectFake1.ErrorList.Add(requiredWarning);

            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake2 = new ValueObjectFake("");
            valueObjectFake2.ErrorList.Add(requiredError);

            valueObjectFake2.ErrorList.Concat(valueObjectFake1.ErrorList);

            Assert.IsTrue(valueObjectFake2.ErrorList.Includes(requiredError) && valueObjectFake2.ErrorList.Includes(requiredWarning));
        }
    }
}