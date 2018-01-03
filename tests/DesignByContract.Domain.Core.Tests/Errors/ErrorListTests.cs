using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Errors
{
    [TestClass]
    public class ErrorlistTests
    {
        [TestMethod]
        public void ErrorlistNewInvalidErrorListNotNull()
        {
            var valueObjectFake = new ValueObjectFake("N");
            Assert.IsTrue(valueObjectFake.ErrorList != null);
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListAnyReturnTrue()
        {
            var valueObjectFake = new ValueObjectFake("N");
            Assert.IsTrue(valueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void ErrorlistNewValidErrorListAnyReturnFalse()
        {
            var valueObjectFake = new ValueObjectFake("Name");
            Assert.IsFalse(valueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListIncludeReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListIncludeReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListAddReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.List.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListAddReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The Name is required.", new Critical(), "");
            var requiredWarning = new ErrorItemDetail("The Name is required.", new Warning(), "");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.List.Add(requiredWarning);
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListAddWithArgsReturnTrue()
        {
            var requiredError = new ErrorItemDetail("The {0} is required.", new Critical(), "", "Name");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.List.Add(requiredError);
            Assert.IsTrue(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorListAddWithArgsReturnFalse()
        {
            var requiredError = new ErrorItemDetail("The {0} is required.", new Critical(), "", "Name");
            var requiredWarning = new ErrorItemDetail("The {0} is required.", new Warning(), "", "Name");
            var valueObjectFake = new ValueObjectFake("");
            valueObjectFake.ErrorList.List.Add(requiredWarning);
            Assert.IsFalse(valueObjectFake.ErrorList.Includes(requiredError));
        }

        [TestMethod]
        public void ErrorlistNewInvalidErrorConcatSuccess()
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