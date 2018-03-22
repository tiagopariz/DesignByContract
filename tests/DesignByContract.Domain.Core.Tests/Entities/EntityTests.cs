using DesignByContract.Domain.Core.Entities;
using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.Entities;
using DesignByContract.Domain.Core.Tests.Mocks.DomainFake.ValueObjects;
using NUnit.Framework;
using System;
using System.Linq;

namespace DesignByContract.Domain.Core.Tests.Entities
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void EntityNewWhenParseValidEntityHasCriticalsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasCriticals);
        }

        [Test]
        public void EntityNewWhenParseValidEntityHasWarningsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasWarnings);
        }

        [Test]
        public void EntityNewWhenParseValidEntityHasInformationsFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.HasInformations);
        }

        [Test]
        public void EntityNewWhenParseValidEntityErrorsAnyFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ErrorList.Any);
        }

        [Test]
        public void EntityNewWhenParseEmptyId()
        {
            var sut = new EntityFake(Guid.Empty, null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [Test]
        public void EntityNewWhenParseValidId()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreNotEqual(Guid.Empty, sut.Id);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNull()
        {
            var sut = new EntityFake(Guid.NewGuid(), null);
            Assert.AreEqual(null, sut.ValueObjectFake);
        }

        [Test]
        public void EntityNewWhenParseValueObjectFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", "fieldName"));
            Assert.AreEqual(Entity.GetPropertyName(() => sut.ValueObjectFake), sut.ValueObjectFake.FieldName);
        }

        [Test]
        public void EntityNewWhenParseNullFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNullFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [Test]
        public void EntityNewWhenParseEmptyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "");
            Assert.AreEqual("EntityFake", sut.FieldName);
        }

        [Test]
        public void EntityNewWhenParseValueObjectEmptyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name", ""));
            Assert.AreEqual("ValueObjectFake", sut.ValueObjectFake.FieldName);
        }

        [Test]
        public void EntityNewWhenParseValueObjectName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual("Name", sut.ValueObjectFake.Name);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNullName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(null, sut.ValueObjectFake.Name);
        }

        [Test]
        public void EntityNewWhenParseValueObjectEmptyName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual("", sut.ValueObjectFake.Name);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameNoErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.ErrorList.Any);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNullNameHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [Test]
        public void EntityNewWhenParseValueObjectEmptyNameHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameIsValidTrue()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.IsValid());
        }

        [Test]
        public void EntityNewWhenParseValueObjectEmptyNameIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(""));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNullNameIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake(null));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameMaximumExceededIsValidFalse()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(false, sut.ValueObjectFake.IsValid());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameMaximumExceededHasErrors()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual(true, sut.ValueObjectFake.ErrorList.Any);
        }

        [Test]
        public void EntityVerifyValueObjectIsRequired()
        {
            Assert.AreEqual(true, EntityFake.ValueObjectFakeRequired);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyMessage()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Max error",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Message);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyLevel()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("Critical",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameMaximumExceededVerifyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name Name Name Name"));
            Assert.AreEqual("ValueObjectFake",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Max error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyMessage()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Min error",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Message);
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyLevel()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("Critical",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.Level.ToString());
        }

        [Test]
        public void EntityNewWhenParseValueObjectNameInsufficientCharactersVerifyFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N"));
            Assert.AreEqual("ValueObjectFake",
                            (sut.ValueObjectFake.
                                ErrorList.List
                                    .FirstOrDefault(x => x.ToString() == "Min error")
                                        as ErrorItemDetail)?.FieldName);
        }

        [Test]
        public void EntityNewWhenValueObjectSetFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("N", "FieldName"), "FieldName");
            sut.ValueObjectFake.SetFieldName("NewFieldName");
            Assert.AreEqual("NewFieldName", sut.ValueObjectFake.FieldName);
        }

        [Test]
        public void EntityNewWhenParseFieldName()
        {
            var sut = new EntityFake(Guid.NewGuid(), new ValueObjectFake("Name"), "fieldName");
            Assert.AreEqual("fieldName", sut.FieldName);
        }
    }
}