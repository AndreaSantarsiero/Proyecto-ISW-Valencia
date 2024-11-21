using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void IsSubClass()
        {
            Assert.IsTrue(typeof(Student).IsSubclassOf(typeof(Person)), "Student class should be declared subclass of Person.");
        }


        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual property:  Enrollments

            PropertyInfo property = typeof(Student).GetProperty("Enrollments");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Enrollments property should be declared virtual.");

        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Student student = new Student();
            Assert.AreNotSame(null, student, "Student: There must be a constructor without parameters.");

            // Collections: Enrollments

            Assert.IsNotNull(student.Enrollments, "Collection of Enrollments not properly initialized. \n Patch the problem adding:  Enrollments = new List<Enrollment>();");

            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, student.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // public Student(string address, string id, string name, int zipCode, string iban)
            Student student = new Student(TestData.EXPECTED_PERSON_ADDRESS, TestData.EXPECTED_PERSON_ID, TestData.EXPECTED_PERSON_NAME, TestData.EXPECTED_PERSON_ZIPCODE, TestData.EXPECTED_STUDENT_IBAN);

            Assert.AreEqual(TestData.EXPECTED_PERSON_ADDRESS, student.Address, "Address not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ID, student.Id, "Id not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_NAME, student.Name, "Name not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ZIPCODE, student.ZipCode, "ZipCode not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_STUDENT_IBAN, student.IBAN, "IBAN not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");

            // Añadido para asegurarnos de que inicializan la colección también en el constructor con parámetros
            Assert.IsNotNull(student.Enrollments, "Collection of Enrollments not properly initialized in the constructor with parameters. \n Patch the problem adding:  Enrollments = new List<Enrollment>(); in the constructor with parameters");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, student.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");
        }
    }
}
