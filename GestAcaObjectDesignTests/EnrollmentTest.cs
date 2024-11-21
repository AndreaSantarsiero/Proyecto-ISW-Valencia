using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class EnrollmentTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are Student, Absences and TaughtCourse

            PropertyInfo property = typeof(Enrollment).GetProperty("Student");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Student property should be declared virtual.");
            property = typeof(Enrollment).GetProperty("Absences");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Absences property should be declared virtual.");
            property = typeof(Enrollment).GetProperty("TaughtCourse");
            Assert.IsTrue(property.GetMethod.IsVirtual, "TaughtCourse property should be declared virtual.");
        }
        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Enrollment enrollment = new Enrollment();
            Assert.AreNotSame(null, enrollment, "Enrollment: There must be a constructor without parameters.");

            // Collections: Absences

            Assert.IsNotNull(enrollment.Absences, "Collection of Absences not properly initialized. \n Patch the problem adding:  Absences = new List<Absence>();");

            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, enrollment.Absences.Count, "Collection of Absences not properly initialized. \n The list should be empty\n");
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // Enrollment(DateTime EnrollmentDate, bool UniquePayment, Student s, TaughtCourse tc)
            Enrollment enrollment = new Enrollment(TestData.EXPECTED_ENROLLMENT_DATE, TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT, TestData.EXPECTED_ENROLLMENT_STUDENT, TestData.EXPECTED_ENROLLMENT_TAUGHTCOURSE);

            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_DATE, enrollment.EnrollmentDate, "EnrollmentDate not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT, enrollment.UniquePayment, "UniquePayment not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_STUDENT, enrollment.Student, "Student not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_TAUGHTCOURSE, enrollment.TaughtCourse, "TaughtCourse not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");

            Assert.IsNotNull(enrollment.Absences, "Collection of Absences not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");

        }
    }
}
