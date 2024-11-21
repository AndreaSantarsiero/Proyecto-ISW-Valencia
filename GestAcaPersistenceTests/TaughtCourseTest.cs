using GestAca.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAcaPersistenceTests
{
    [TestClass]
    public class TaughtCourseTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {

            //public TaughtCourse(DateTime endDate, int id, int quotas, int sessionDuration, DateTime startDateTime, string teachingDay, int totalPrice, Course c)
            TaughtCourse taughtCourse = new TaughtCourse(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, TestData.EXPECTED_TAUGHTCOURSE_ID, TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, TestData.EXPECTED_TAUGHTCOURSE_COURSE);
            dal.Insert(taughtCourse);
            dal.Commit();

            TaughtCourse taugthCourseFromDAL = dal.GetAll<TaughtCourse>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, taugthCourseFromDAL.EndDate, "EndDate attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_ID, taugthCourseFromDAL.Id, "Id attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, taugthCourseFromDAL.Quotas, "Quotas attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, taugthCourseFromDAL.SessionDuration, "SessionDuration attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, taugthCourseFromDAL.StartDateTime, "StartDateTime attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, taugthCourseFromDAL.TeachingDay, "TeachingDay attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, taugthCourseFromDAL.TotalPrice, "TotalPrice attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_COURSE, taugthCourseFromDAL.Course, "Course attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially empty because they are all 0..*

            // Teachers
            Assert.IsNotNull(taugthCourseFromDAL.Teachers, "Collection of Teachers not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, taugthCourseFromDAL.Teachers.Count, "Collection of Teachers not properly initialized. \n The list should be empty\n");

            // Enrollments
            Assert.IsNotNull(taugthCourseFromDAL.Enrollments, "Collection of Enrollments not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, taugthCourseFromDAL.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");

        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
            Course c = new Course(TestData.EXPECTED_COURSE_DESCRIPTION, TestData.EXPECTED_COURSE_NAME);
            dal.Insert(c);

            TaughtCourse taughtCourse = new TaughtCourse(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, TestData.EXPECTED_TAUGHTCOURSE_ID, TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, c);
            dal.Insert(taughtCourse);
            dal.Commit();
            TaughtCourse taugthCourseFromDAL = dal.GetAll<TaughtCourse>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, taugthCourseFromDAL.EndDate, "EndDate attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_ID, taugthCourseFromDAL.Id, "Id attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, taugthCourseFromDAL.Quotas, "Quotas attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, taugthCourseFromDAL.SessionDuration, "SessionDuration attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, taugthCourseFromDAL.StartDateTime, "StartDateTime attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, taugthCourseFromDAL.TeachingDay, "TeachingDay attribute properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, taugthCourseFromDAL.TotalPrice, "TotalPrice attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(c, taugthCourseFromDAL.Course, "Course not properly initialized.");

            // Verify bidirectional relationships: all collections are not null after inserting one element      

            Assert.AreEqual(c.TaughtCourses.FirstOrDefault(), taugthCourseFromDAL, "Bidirectional TaughtCourse-Course relationship not properly set");

        }
    }
}
