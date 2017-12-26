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
        public void EntityNewWhenParseValidEntityHasCriticalsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasCriticals);
        }

        [TestMethod]
        public void EntityNewWhenParseValidEntityHasWarningsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasWarnings);
        }

        [TestMethod]
        public void EntityNewWhenParseValidEntityHasInformationsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasInformations);
        }

        [TestMethod]
        public void EntityNewWhenParseValidEntityErrorsAnyFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [TestMethod]
        public void EntityNewWhenParseEmptyId()
        {
            var sut = new EntityFake(Guid.Empty, null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [TestMethod]
        public void EntityNewWhenParseValidId()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNull()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreEqual(null, sut.ValueObjectFake);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", "fieldName"));
            Assert.AreEqual(Entity.GetPropertyName(() => sut.ValueObjectFake), sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseNullFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNullFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseEmptyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "");
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectEmptyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", ""));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("Name", sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNullName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(null, sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectEmptyName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual("", sut.ValueObjectFake.Name);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameNoErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNullNameHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectEmptyNameHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameIsValidTrue()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectEmptyNameIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNullNameIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameMaximumExceededIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameMaximumExceededHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [TestMethod]
        public void EntityVerifyValueObjectIsRequired()
        { 
            Assert.AreEqual(true, EntityFake.ValueObjectFakeRequired);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyMessage()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Max error", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyLevel()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Critical", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("ValueObjectFake", 
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyMessage()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Min error",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyLevel()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Critical",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [TestMethod]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("ValueObjectFake",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenValueObjectSetFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N", "FieldName"), "FieldName");
            sut.ValueObjectFake.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.ValueObjectFake.FieldName);
        }

        [TestMethod]
        public void EntityNewWhenParseFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }
    }
}