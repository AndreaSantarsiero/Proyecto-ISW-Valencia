using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class TeacherTest
    {
        [TestMethod]
        public void IsSubClass()
        {
            Assert.IsTrue(typeof(Teacher).IsSubclassOf(typeof(Person)), "Teacher class should be declared subclass of Person.");
        }

        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual property:  TaughtCourses

            PropertyInfo property = typeof(Teacher).GetProperty("TaughtCourses");
            Assert.IsTrue(property.GetMethod.IsVirtual, "TaughtCourses property should be declared virtual.");

        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Teacher teacher = new Teacher();
            Assert.AreNotSame(null, teacher, "Teacher: There must be a constructor without parameters.");

            // Collections: TaughtCourses

            Assert.IsNotNull(teacher.TaughtCourses, "Collection of TaughtCourse not properly initialized. \n Patch the problem adding:  TaughtCourses = new List<TaughtCourse>();");

            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, teacher.TaughtCourses.Count, "Collection of Taught not properly initialized. \n The list should be empty\n");
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // public Teacher(string address, string id, string name, int zipCode, string ssn)
            Teacher teacher = new Teacher(TestData.EXPECTED_PERSON_ADDRESS, TestData.EXPECTED_PERSON_ID, TestData.EXPECTED_PERSON_NAME, TestData.EXPECTED_PERSON_ZIPCODE, TestData.EXPECTED_TEACHER_SSN);

            Assert.AreEqual(TestData.EXPECTED_PERSON_ADDRESS, teacher.Address, "Address not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ID, teacher.Id, "Id not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_NAME, teacher.Name, "Name not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ZIPCODE, teacher.ZipCode, "ZipCode not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TEACHER_SSN, teacher.Ssn, "Ssn not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");

            // Añadido para asegurarnos de que inicializan la colección también en el constructor con parámetros
            Assert.IsNotNull(teacher.TaughtCourses, "Collection of TaughtCourse not properly initialized in the constructor with parameters. \n Patch the problem adding:  TaughtCourses = new List<TaughtCourse>(); in the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, teacher.TaughtCourses.Count, "Collection of Taught not properly initialized. \n The list should be empty\n");
        }
    }
}
