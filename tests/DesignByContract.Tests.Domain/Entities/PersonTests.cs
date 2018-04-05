using DesignByContract.Domain.Entities;
using DesignByContract.Domain.ValueObjects;
using NUnit.Framework;
using System;

namespace DesignByContract.Tests.Domain.Entities
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [Category("Entities")]
        public void EmailNewEmptyName()
        {
            var sut = new Person(Guid.NewGuid(),
                                 new PersonName(""),
                                 new Email("teste@teste.com"),
                                 new Category(Guid.NewGuid(), "Física"));

            Assert.AreEqual(sut.IsValid(), false);
        }
    }
}