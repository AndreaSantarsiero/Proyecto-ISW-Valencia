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
        public class TeacherTest : BaseTest
        {
            [TestMethod]
            public void StoresInitialData()
            {

            // public Teacher(string address, string id, string name, int zipCode, string ssn)
            Teacher teacher = new Teacher(TestData.EXPECTED_PERSON_ADDRESS, TestData.EXPECTED_PERSON_ID, TestData.EXPECTED_PERSON_NAME, TestData.EXPECTED_PERSON_ZIPCODE, TestData.EXPECTED_TEACHER_SSN);

            dal.Insert(teacher);
            dal.Commit();

            Teacher teacherFromDAL = dal.GetAll<Teacher>().First();

            // Test non virtual properties properly stored

            Assert.AreEqual(TestData.EXPECTED_PERSON_ADDRESS, teacherFromDAL.Address, "Address attribute not properly stored.");
            //Assert.AreEqual(TestData.EXPECTED_PERSON_ID, teacherFromDAL.Id, "Id attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_NAME, teacherFromDAL.Name, "Name attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ZIPCODE, teacherFromDAL.ZipCode, "ZipCode attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_TEACHER_SSN, teacherFromDAL.Ssn, "Ssn attribute not properly stored.");

            // Test virtual properties properly stored
            // They must be initially empty because they are all 0..*
            // TaughtCourses

            Assert.IsNotNull(teacherFromDAL.TaughtCourses, "Collection of TaughtCouruse not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, teacherFromDAL.TaughtCourses.Count, "Collection of TaughtCourses not properly initialized. \n The list should be empty\n");
        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
        
 
        }
    }
    }

