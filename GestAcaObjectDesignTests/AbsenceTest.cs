using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using GestAca.Entities;

namespace GestAcaObjectDesignTests
{
    [TestClass]
    public class AbsenceTest
    {
        [TestMethod]
        public void ConstructorInitializesProps()
        {
            // Enrollment(DateTime Date)
            Absence absence = new Absence(TestData.EXPECTED_ABSENCE_DATE);

            Assert.AreEqual(TestData.EXPECTED_ABSENCE_DATE, absence.Date, "Date not properly initialized. Please check whether you have correctly assigned the parameters in the corresponding class.");
        }
    }
}
