using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class ClassroomTest
    {

        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are TaughtCourse

            PropertyInfo property = typeof(Classroom).GetProperty("TaughtCourses");
            Assert.IsTrue(property.GetMethod.IsVirtual, "TaughtCourses property should be declared virtual.");
        }
        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Classroom classRoom = new Classroom();
            Assert.AreNotSame(null, classRoom, "Classroom: There must be a constructor without parameters.");

            // Collections: TaughtCourses

            Assert.IsNotNull(classRoom.TaughtCourses, "Collection of TaughtCourses not properly initialized. \n Patch the problem adding:  TaughtCourses = new List<TaughtCourse>();");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, classRoom.TaughtCourses.Count, "Collection of TaughtCourses not properly initialized. \n The list should be empty\n");
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // Classroom(Int MaxCapacity, string Name)
            Classroom classRoom = new Classroom(TestData.EXPECTED_CLASSROOM_MAXCAPACITY, TestData.EXPECTED_CLASSROOM_NAME);

            Assert.AreEqual(TestData.EXPECTED_CLASSROOM_MAXCAPACITY, classRoom.MaxCapacity, "MaxCapacity not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_CLASSROOM_NAME, classRoom.Name, "Name not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");

            // Añadido para asegurarnos de que llaman a this()
            Assert.IsNotNull(classRoom.TaughtCourses, "Collection of Taught Courses not properly initialized. \n Patch the problem adding:  :this() to the constructor with parameters");


        }
    }
}
