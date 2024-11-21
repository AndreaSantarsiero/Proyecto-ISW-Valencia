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
    public class TaughtCourseTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are Classroom, Course, Enrollment, and Teacher
            PropertyInfo property = typeof(TaughtCourse).GetProperty("Classroom");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Classroom property should be declared virtual.");
            property = typeof(TaughtCourse).GetProperty("Course");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Course property should be declared virtual.");
            property = typeof(TaughtCourse).GetProperty("Enrollments");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Enrollments property should be declared virtual.");
            property = typeof(TaughtCourse).GetProperty("Teachers");
            Assert.IsTrue(property.GetMethod.IsVirtual, "Teachers property should be declared virtual.");
        }

        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            TaughtCourse taughtCourse = new TaughtCourse();
            Assert.AreNotSame(null, taughtCourse, "TaughtCourse: There must be a constructor without parameters.");

            // Collections: Enrollments, Teachers
            Assert.IsNotNull(taughtCourse.Enrollments, "Collection of Enrollments not properly initialized. \n Patch the problem adding:  Enrollment = new List<Enrollment>();");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, taughtCourse.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");

            Assert.IsNotNull(taughtCourse.Teachers, "Collection of Teachers not properly initialized. \n Patch the problem adding:  Teacher = new List<Teacher>();");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, taughtCourse.Teachers.Count, "Collection of Teachers not properly initialized. \n The list should be empty\n");
        }

        [TestMethod]
        public void ConstructorInitializesProps()
        {
            //public TaughtCourse(DateTime endDate, int id, int quotas, int sessionDuration, DateTime startDateTime, string teachingDay, int totalPrice, Course c):this()
           
            TaughtCourse taughtCourse = new TaughtCourse(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, TestData.EXPECTED_TAUGHTCOURSE_ID, TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, TestData.EXPECTED_TAUGHTCOURSE_COURSE);

            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, taughtCourse.EndDate, "EndDate not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, taughtCourse.Quotas, "Quotas not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, taughtCourse.SessionDuration, "SessionDuration not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, taughtCourse.StartDateTime, "StartDateTime not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, taughtCourse.TeachingDay, "TeachingDay not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, taughtCourse.TotalPrice, "TotalPrice not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_COURSE, taughtCourse.Course, "Course not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");

            Assert.IsNotNull(taughtCourse.Enrollments, "Collection of Enrollments not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");
            Assert.IsNotNull(taughtCourse.Teachers, "Collection of Teachers not properly initialized. \n Patch the problem adding: :this() to the constructor with parameters");

        }
    }
}
