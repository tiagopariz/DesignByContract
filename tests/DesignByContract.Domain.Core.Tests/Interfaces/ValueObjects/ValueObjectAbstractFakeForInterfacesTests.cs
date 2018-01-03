using DesignByContract.Domain.Core.Errors;
using DesignByContract.Domain.Core.Interfaces.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignByContract.Domain.Core.Tests.Interfaces.ValueObjects
{
    [TestClass]
    public abstract class ValueObjectAbstractFakeForInterfacesTests
    {
        public abstract IValueObject GetValueObjectInstance();


        [TestMethod]
        public void ValueObjectErrorListAddReturnAnyTrue()
        {
            var entity = GetValueObjectInstance();
            var errorList = entity.ErrorList;
            errorList.Add(new ErrorItemDetail("Test", new Critical(), ""));
            Assert.IsTrue(errorList.Any);
        }

        [TestMethod]
        public void ValueObjectValidSpecificationReturnSpecificarion()
        {
            var entity = GetValueObjectInstance();
            var validation = entity.ValidSpecification;
            Assert.IsTrue(validation != null);
        }

        [TestMethod]
        public void ValueObjectFieldNameReturnClassName()
        {
            var entity = GetValueObjectInstance();
            Assert.IsTrue(entity.FieldName == "ValueObjectFakeForInterfaces");
        }
    }
}