using DesignByContract.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewEmptyAddress()
        {
            var sut = new Email("");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewNullAddress()
        {
            var sut = new Email(null);
            Assert.AreEqual(sut.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewWhiteSpaceAddress()
        {
            var sut = new Email(" ");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewValidAddres()
        {
            var sut = new Email("contato@email.com.br");
            Assert.AreEqual("contato@email.com.br", sut.Address);
            Assert.AreEqual(sut.IsValid(), true);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewInvalidAddress()
        {
            var sut = new Email("contato#email.com.br");
            Assert.AreEqual(sut.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewErrorWhemAddressMaxLengthExceeded()
        {
            var address = "contato@email.com.br";

            while (address.Length < Email.AddressMaxLength)
                address += address;

            var sut = new Email(address);
            Assert.AreEqual(sut.IsValid(), false);
        }

        [TestMethod]
        [TestCategory("ValueObjects")]
        public void EmailNewErrorWhemAddressMinLengthAllowed()
        {
            var sut = new Email("@");
            Assert.AreEqual(sut.IsValid(), false);
        }
    }
}