using GestAca.Entities;
using GestAca.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAcaPersistenceTests
{
    [TestClass]
    public class ClassroomTest : BaseTest
    {
        [TestMethod]
        public void StoresInitialData()
        {

            // public Classroom(int maxCapacity, string name)
            Classroom classRoom = new Classroom(TestData.EXPECTED_CLASSROOM_MAXCAPACITY, TestData.EXPECTED_CLASSROOM_NAME);
            dal.Insert(classRoom);
            dal.Commit();

            Classroom classroomFromDAL = dal.GetAll<Classroom>().First();

            // Test non virtual properties properly stored
            Assert.AreEqual(TestData.EXPECTED_CLASSROOM_MAXCAPACITY, classroomFromDAL.MaxCapacity, "MaxCapacity attribute not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_CLASSROOM_NAME, classroomFromDAL.Name, "Name attribute properly stored.");

            // Test virtual properties properly stored
            // They must be initially empty because they are all 0..*

            // TaughtCourses
            Assert.IsNotNull(classroomFromDAL.TaughtCourses, "Collection of TaughtCourses not properly stored.");
            Assert.AreEqual(TestData.EXPECTED_EMPTY_LIST_COUNT, classroomFromDAL.TaughtCourses.Count, "Collection of TaughtCourses not properly initialized. \n The list should be empty\n");

        }
    }
}
