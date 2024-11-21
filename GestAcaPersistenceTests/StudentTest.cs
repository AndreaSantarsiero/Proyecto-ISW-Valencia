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
        public class StudentTest : BaseTest
        {
            [TestMethod]
            public void StoresInitialData()
            {

            // public Student(string address, string id, string name, int zipCode, string iban)
            Student student = new Student(TestData.EXPECTED_PERSON_ADDRESS, TestData.EXPECTED_PERSON_ID, TestData.EXPECTED_PERSON_NAME, TestData.EXPECTED_PERSON_ZIPCODE, TestData.EXPECTED_STUDENT_IBAN);

            dal.Insert(student);
            dal.Commit();

            Student studentFromDAL = dal.GetAll<Student>().First();


            // Test non virtual properties properly stored

            Assert.AreEqual(TestData.EXPECTED_PERSON_ADDRESS, studentFromDAL.Address, "Address attribute not properly stored.");
            //Assert.AreEqual(TestData.EXPECTED_PERSON_ID, student.Id, "Id  attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_NAME, studentFromDAL.Name, "Name  attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_PERSON_ZIPCODE, studentFromDAL.ZipCode, "ZipCode attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_STUDENT_IBAN, studentFromDAL.IBAN, "IBAN attribute not properly stored.");


            // Test virtual properties properly stored
            // They must be initially empty because they are all 0..*
            // Enrollments
            
            Assert.IsNotNull(studentFromDAL.Enrollments, "Collection of Enrollments not properly stored");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, studentFromDAL.Enrollments.Count, "Collection of Enrollments not properly initialized. \n The list should be empty\n");
            
        }

        [TestMethod]
        public void StoresDataWithRelations()
        {
        

 
        }
    }
    }

