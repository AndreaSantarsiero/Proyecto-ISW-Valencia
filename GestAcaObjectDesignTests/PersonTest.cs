using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class PersonTest
    {

        [TestMethod]
        public void IsAbstractClass()
        {
            Assert.IsTrue(typeof(Person).IsAbstract, "Person class should be declared abstract."); 
        }
        
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // No Virtual properties

        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {
            // No Collections and Person is Abstract class
 
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // Person is Abstract class. Subclasses will check this out
        }
    }
}
