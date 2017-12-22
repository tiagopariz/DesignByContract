using System.Linq;
using DesignByContract.Domain.Core.Errors;
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
            var sut = new ValueObjectFake("", "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Null_FieldName()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Empty_FieldName()
        {
            var sut = new ValueObjectFake("", "");
            Assert.AreEqual("ValueObjectFake", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual("Name", sut.Name);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Null_Name()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(null, sut.Name);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Empty_Name()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual("", sut.Name);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_No_Errors()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Null_Name_Has_Errors()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Empty_Name_Has_Errors()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_IsValid_True()
        {
            var sut = new ValueObjectFake("Name");
            Assert.AreEqual(true, sut.IsValid());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Null_Name_IsValid_False()
        {
            var sut = new ValueObjectFake(null);
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Empty_Name_IsValid_False()
        {
            var sut = new ValueObjectFake("");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Insufficient_Characters_IsValid_False()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Insufficient_Characters_Has_Errors()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Maximum_Exceeded_IsValid_False()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(false, sut.IsValid());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Maximum_Exceeded_Has_Errors()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual(true, sut.ErrorList.Any);
        }

        [TestMethod]
        public void ValueObject_Verify_Name_MinLength_Value()
        { 
            Assert.AreEqual(3, ValueObjectFake.NameMinLength);
        }

        [TestMethod]
        public void ValueObject_Verify_Name_MaxLength_Value()
        { 
            Assert.AreEqual(15, ValueObjectFake.NameMaxLength);
        }

        [TestMethod]
        public void ValueObject_Verify_Name_Is_Required()
        { 
            Assert.AreEqual(true, ValueObjectFake.NameRequired);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Maximum_Exceeded_Verify_Message()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Max error", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Maximum_Exceeded_Verify_Level()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("Critical", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Maximum_Exceeded_Verify_FieldName()
        {
            var sut = new ValueObjectFake("Name Name Name Name");
            Assert.AreEqual("ValueObjectFake", 
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Insufficient_Characters_Verify_Message()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Min error",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Insufficient_Characters_Verify_Level()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("Critical",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void ValueObject_New_When_Parse_Name_Insufficient_Characters_Verify_FieldName()
        {
            var sut = new ValueObjectFake("N");
            Assert.AreEqual("ValueObjectFake",
                            (sut.ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void ValueObject_When_Set_Field_Name()
        {
            var sut = new ValueObjectFake("Name", "FieldName");
            sut.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.FieldName);
        }

        [TestMethod]
        public void ValueObject_When_Validate()
        {
            var sut = new ValueObjectFake("N");
            var errorsCount = sut.ErrorList.List.Count;
            sut.Validate();
            // TODO: Talvez seja interessante o Validate não duplicar os erros
            Assert.AreEqual(errorsCount * 2, sut.ErrorList.List.Count);
        }
    }
}
