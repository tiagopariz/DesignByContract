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
    }
}
