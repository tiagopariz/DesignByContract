using DesignByContract.Core.Domain.Errors;
using DesignByContract.Core.Tests.Domain.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;
using System.Linq;

namespace DesignByContract.Core.Tests.Domain.ValueObjects
{
    [TestFixture]
    public class ValueObjectTests
    {
        [Test]
        public void ValueObjectNewWhenParseFieldName()
        {
            var sut = new ValueObjectFake("", "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }

        [Test]
        public void ValueObjectNewWhenParseNullFieldName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [Test]
        public void ValueObjectNewWhenParseEmptyFieldName()
        {
            var sut = new ValueObjectFake("", "");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [Test]
        public void ValueObjectNewWhenParseName()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual("Name", sut.Name);
        }

        [Test]
        public void ValueObjectNewWhenParseNullName()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(null, sut.Name);
        }

        [Test]
        public void ValueObjectNewWhenParseEmptyName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("", sut.Name);
        }

        [Test]
        public void ValueObjectNewWhenParseNameNoErrors()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [Test]
        public void ValueObjectNewWhenParseNullNameHasErrors()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [Test]
        public void ValueObjectNewWhenParseEmptyNameHasErrors()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [Test]
        public void ValueObjectNewWhenParseNameIsValidTrue()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(true, sut.IsValid());
        }

        [Test]
        public void ValueObjectNewWhenParseNullNameIsValidFalse()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(false, sut.IsValid());
        }

        [Test]
        public void ValueObjectNewWhenParseEmptyNameIsValidFalse()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(false, sut.IsValid());
        }

        [Test]
        public void ValueObjectNewWhenParseNameInsufficientCharactersIsValidFalse()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(false, sut.IsValid());
        }

        [Test]
        public void ValueObjectNewWhenParseNameInsufficientCharactersHasErrors()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [Test]
        public void ValueObjectNewWhenParseNameMaximumExceededIsValidFalse()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(false, sut.IsValid());
        }

        [Test]
        public void ValueObjectNewWhenParseNameMaximumExceededHasErrors()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [Test]
        public void ValueObjectVerifyNameMinLengthValue()
        {
            Assert.AreEqual(3, ValueObjectFake.NameMinLength);
        }

        [Test]
        public void ValueObjectVerifyNameMaxLengthValue()
        {
            Assert.AreEqual(15, ValueObjectFake.NameMaxLength);
        }

        [Test]
        public void ValueObjectVerifyNameIsRequired()
        {
            Assert.AreEqual(true, ValueObjectFake.NameRequired);
        }

        [Test]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyMessage()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Max error",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [Test]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyLevel()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Critical",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [Test]
        public void ValueObjectNewWhenParseNameMaximumExceededVerifyFieldName()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("ValueObjectFake",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [Test]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyMessage()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Min error",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [Test]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyLevel()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Critical",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [Test]
        public void ValueObjectNewWhenParseNameInsufficientCharactersVerifyFieldName()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("ValueObjectFake",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [Test]
        public void ValueObjectWhenSetFieldName()
        {
            var sut = new ValueObjectFake("Name", "FieldName");
            sut.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.FieldName);
        }
    }
}