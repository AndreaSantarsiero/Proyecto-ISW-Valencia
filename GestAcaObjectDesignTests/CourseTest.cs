using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void VirtualPropertiesDefined()
        {
            // Virtual properties are TaughtCourse

            PropertyInfo property = typeof(Course).GetProperty("TaughtCourses");
            Assert.IsTrue(property.GetMethod.IsVirtual, "TaughtCourses property should be declared virtual.");
        }
        [TestMethod]
        public void NoParamsConstructorInitializesCollections()
        {

            Course course = new Course();
            Assert.AreNotSame(null, course, "Course: There must be a constructor without parameters.");

            // Collections: TaughtCourses

            Assert.IsNotNull(course.TaughtCourses, "Collection of Taught Courses not properly initialized. \n Patch the problem adding:  TaughtCourses = new List<TaughtCourse>();");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, course.TaughtCourses.Count, "Collection of Taught Courses not properly initialized. \n The list should be empty\n");
        }



        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // Course(string Description, string Name)
            Course course = new Course(TestData.EXPECTED_COURSE_DESCRIPTION, TestData.EXPECTED_COURSE_NAME);

            Assert.AreEqual(TestData.EXPECTED_COURSE_DESCRIPTION, course.Description, "Description not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            Assert.AreEqual(TestData.EXPECTED_COURSE_NAME, course.Name, "Name not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
            
            // Añadido para asegurarnos de que llaman a this()
            Assert.IsNotNull(course.TaughtCourses, "Collection of Taught Courses not properly initialized. \n Patch the problem adding:  :this() to the constructor with parameters");
            

        }
    }
}
