using DesignByContract.Domain.Core.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;

namespace DesignByContract.Domain.Core.Tests.ValueObjects
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void ValueObjectNewWhenParseFieldName()
        {
            var sut = new ValueObjectFake("", "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNullFieldName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseEmptyFieldName()
        {
            var sut = new ValueObjectFake("", "");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseName()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual("Name", sut.Name);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNullName()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(null, sut.Name);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseEmptyName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("", sut.Name);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameNoErrors()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNullNameHasErrors()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseEmptyNameHasErrors()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameIsValidTrue()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(true, sut.IsValid());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNullNameIsValidFalse()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseEmptyNameIsValidFalse()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameInsufficientCharactersIsValidFalse()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameInsufficientCharactersHasErrors()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameMaximumExceededIsValidFalse()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameMaximumExceededHasErrors()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObjectVerifyNameMinLengthValue()
        { 
            Assert.AreEqual(3, ValueObjectFake.NameMinLength);
        }

        [TestMethod]
        public void ValueObjectVerifyNameMaxLengthValue()
        { 
            Assert.AreEqual(15, ValueObjectFake.NameMaxLength);
        }

        [TestMethod]
        public void ValueObjectVerifyNameIsRequired()
        { 
            Assert.AreEqual(true, ValueObjectFake.NameRequired);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyMessage()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Max error", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyLevel()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Critical", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyFieldName()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("ValueObjectFake", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyMessage()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Min error",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyLevel()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Critical",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyFieldName()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("ValueObjectFake",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void ValueObjectWhenSetFieldName()
        {
            var sut = new ValueObjectFake("Name", "FieldName");
            sut.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.FieldName);
        }
    }
}