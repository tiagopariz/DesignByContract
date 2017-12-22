using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.ValueObjects
{
    [TestClass]
    public class ValueObjectTests
    {
        [TestMethod]
        public void ValueObject_New_When_Parse_FieldName()
        {
            var sut = new ValueObjectFake("fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Null_FieldName()
        {
            var sut = new ValueObjectFake();
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Empty_FieldName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }
    }
}
