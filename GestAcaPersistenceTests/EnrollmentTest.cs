using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestAca.Entities;

namespace GestAcaPersistenceTests
{
    

        [TestClass]
        public class EnrollmentTest : BaseTest
        {
            [TestMethod]
            public void StoresInitialData()
            {
            
            // public Enrollment(DateTime EnrollmentDate, bool UniquePayment, Student s, TaughtCourse tc)

            Enrollment enrollment = new Enrollment(TestData.EXPECTED_ENROLLMENT_DATE,TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT,TestData.EXPECTED_ENROLLMENT_STUDENT,TestData.EXPECTED_ENROLLMENT_TAUGHTCOURSE);
            dal.Insert(enrollment);
            dal.Commit();

            Enrollment enrollmentFromDAL = dal.GetAll<Enrollment>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_DATE, enrollmentFromDAL.EnrollmentDate, "EnrollmentDate attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT, enrollmentFromDAL.UniquePayment, "UniquePayment attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_STUDENT, enrollmentFromDAL.Student, "Student not properly initialized.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_TAUGHTCOURSE, enrollmentFromDAL.TaughtCourse, "TaughtCourse not properly initialized.");
            // Test virtual properties properly stored
            // They must be initially empty because they are all 0..*
            // Absences
            Assert.IsNotNull(enrollmentFromDAL.Absences, "Collection of Absences not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, enrollmentFromDAL.Absences.Count, "Collection of Absences not properly initialized. \n The list should be empty\n");
        }

        [TestMethod]
            public void StoresDataWithRelations()
            {
            Student s = new Student(TestData.EXPECTED_PERSON_ADDRESS, TestData.EXPECTED_PERSON_ID, TestData.EXPECTED_PERSON_NAME, TestData.EXPECTED_PERSON_ZIPCODE, TestData.EXPECTED_STUDENT_IBAN);
            Course c = new Course(TestData.EXPECTED_COURSE_DESCRIPTION, TestData.EXPECTED_COURSE_NAME);
            TaughtCourse tc = new TaughtCourse(TestData.EXPECTED_TAUGHTCOURSE_ENDDATE, TestData.EXPECTED_TAUGHTCOURSE_ID, TestData.EXPECTED_TAUGHTCOURSE_QUOTAS, TestData.EXPECTED_TAUGHTCOURSE_SESSION_DURATION, TestData.EXPECTED_TAUGHTCOURSE_STARTDATE, TestData.EXPECTED_TAUGHTCOURSE_TEACHING_DAY, TestData.EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, c);
            dal.Insert(s);
            dal.Insert(c);
            dal.Insert(tc);

            Enrollment enrollment = new Enrollment(TestData.EXPECTED_ENROLLMENT_DATE, TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT, s, tc);
            dal.Insert(enrollment);
            dal.Commit();
            Enrollment enrollmentFromDAL = dal.GetAll<Enrollment>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_DATE, enrollmentFromDAL.EnrollmentDate, "EnrollmentDate attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_ENROLLMENT_UNIQUEPAYMENT, enrollmentFromDAL.UniquePayment, "UniquePayment attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially instanced because they are all 1
            Assert.AreEqual(s, enrollmentFromDAL.Student, "Student not properly initialized.");
            Assert.AreEqual(tc, enrollmentFromDAL.TaughtCourse, "TaughtCourse not properly initialized.");

            // Verify bidirectional relationships: all collections are not null after inserting one element      

            Assert.AreEqual(s.Enrollments.FirstOrDefault(), enrollmentFromDAL, "Bidirectional Enrollment-Student relationship not properly set");
            Assert.AreEqual(tc.Enrollments.FirstOrDefault(), enrollmentFromDAL, "Bidirectional Enrollment-TaughtCourse relationship not properly created.");

 
        }
    }
    }

