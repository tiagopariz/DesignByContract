using DesignByContract.Domain.ValueObjects;
using NUnit.Framework;

namespace DesignByContract.Tests.Domain.ValueObjects
{
    [TestFixture]
    public class EmailTests
    {
        [Test]
        [Category("ValueObjects")]
        public void EmailNewEmptyAddress()
        {
            var sut = new Email("");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewNullAddress()
        {
            var sut = new Email(null);
            Assert.AreEqual(sut.IsValid(), false);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewWhiteSpaceAddress()
        {
            var sut = new Email(" ");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewValidAddres()
        {
            var sut = new Email("contato@email.com.br");
            Assert.AreEqual("contato@email.com.br", sut.Address);
            Assert.AreEqual(sut.IsValid(), true);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewInvalidAddress()
        {
            var sut = new Email("contato#email.com.br");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewErrorWhemAddressMaxLengthExceeded()
        {
            var address = "contato@email.com.br";

            while (address.Length < Email.AddressMaxLength)
                address += address;

            var sut = new Email(address);
            Assert.AreEqual(sut.IsValid(), false);
        }

        [Test]
        [Category("ValueObjects")]
        public void EmailNewErrorWhemAddressMinLengthAllowed()
        {
            var sut = new Email("@");
            Assert.AreEqual(sut.IsValid(), false);
        }
    }
}