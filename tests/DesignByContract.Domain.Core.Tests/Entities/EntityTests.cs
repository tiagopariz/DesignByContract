using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Tests.FakeDomain.Entities;
using DesignByContract.Domain.Core.Tests.FakeDomain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DesignByContract.Domain.Core.Tests.Entities
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void Entity_New_When_Parse_Valid_Entity_HasCriticals_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasCriticals);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Valid_Entity_HasWarnings_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasWarnings);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Valid_Entity_HasInformations_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasInformations);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Valid_Entity_Errors_Any_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Empty_Id()
        {
            var sut = new EntityFake(Guid.Empty, null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Valid_Id()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Null()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreEqual(null, sut.ValueObjectFake);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", "fieldName"));
            Assert.AreEqual(Entity.GetPropertyName(() => sut.ValueObjectFake), sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Null_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Null_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_Empty_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "");
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Empty_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", ""));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("Name", sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Null_Name()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(null, sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Empty_Name()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual("", sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_No_Errors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Null_Name_Has_Errors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Empty_Name_Has_Errors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_IsValid_True()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Empty_Name_IsValid_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Null_Name_IsValid_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Insufficient_Characters_IsValid_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Insufficient_Characters_Has_Errors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Maximum_Exceeded_IsValid_False()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Maximum_Exceeded_Has_Errors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void Entity_Verify_ValueObject_Is_Required()
        { 
            Assert.AreEqual(true, EntityFake.ValueObjectFakeRequired);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Maximum_Exceeded_Verify_Message()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Max error", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Maximum_Exceeded_Verify_Level()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Critical", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Maximum_Exceeded_Verify_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("ValueObjectFake", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Insufficient_Characters_Verify_Message()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Min error",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Insufficient_Characters_Verify_Level()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Critical",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void Entity_New_When_Parse_ValueObject_Name_Insufficient_Characters_Verify_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("ValueObjectFake",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_ValueObject_Set_Field_Name()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N", "FieldName"), "FieldName");
            sut.ValueObjectFake.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void Entity_New_When_Parse_FieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }
    }
}