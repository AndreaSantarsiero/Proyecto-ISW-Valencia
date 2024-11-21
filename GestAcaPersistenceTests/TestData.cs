using System;
using GestAca.Entities;

namespace GestAcaPersistenceTests
{
    public class TestData
    {
        //GENERIC
        public static int EXPECTED_EMPTY_LIST_COUNT = 0;
        public static int EXPECTED_ONE_ELEMENT_LIST_COUNT = 1;

        //PERSON
        //string address, string id, string name, int zipCode,
        public static string EXPECTED_PERSON_ADDRESS = "13 Rue del Percebe";
        public static string EXPECTED_PERSON_ID = "11111111A";
        public static string EXPECTED_PERSON_NAME = "Mortadelo Martinez";
        public static int EXPECTED_PERSON_ZIPCODE = 46022;

        //TEACHER
        // string Ssn
        public static string EXPECTED_TEACHER_SSN = "46-023023-28";


        //STUDENT
        // string iban

        public static string EXPECTED_STUDENT_IBAN = "ES22 1111 2222 3333 4444 5555";

        //COURSE
        //string descr, string name
        public static string EXPECTED_COURSE_DESCRIPTION = "Software Engineering Intro - 1st Year";
        public static string EXPECTED_COURSE_NAME = "Software Engineering";
        
        //TAUGHTCOURSE
        //DateTime endDate, int id, int quotas, int sessionDuration, DateTime startDateTime, string teachingDay, int totalPrice, Course c 
        public static DateTime EXPECTED_TAUGHTCOURSE_ENDDATE = DateTime.Today;
        public static int EXPECTED_TAUGHTCOURSE_ID = 11555;
        public static int EXPECTED_TAUGHTCOURSE_QUOTAS = 12;
        public static int EXPECTED_TAUGHTCOURSE_SESSION_DURATION = 120;
        public static DateTime EXPECTED_TAUGHTCOURSE_STARTDATE = DateTime.Today;
        public static string EXPECTED_TAUGHTCOURSE_TEACHING_DAY = "Monday";
        public static int EXPECTED_TAUGHTCOURSE_TOTAL_PRICE = 3200;
        public static Course EXPECTED_TAUGHTCOURSE_COURSE = new Course(EXPECTED_COURSE_DESCRIPTION, EXPECTED_COURSE_NAME);

        //ENROLLMENT
        public static DateTime EXPECTED_ENROLLMENT_DATE = DateTime.Now;
        public static bool EXPECTED_ENROLLMENT_UNIQUEPAYMENT = true;
        public static Student EXPECTED_ENROLLMENT_STUDENT = new Student(EXPECTED_PERSON_ADDRESS, EXPECTED_PERSON_ID, EXPECTED_PERSON_NAME, EXPECTED_PERSON_ZIPCODE, EXPECTED_STUDENT_IBAN);
        public static TaughtCourse EXPECTED_ENROLLMENT_TAUGHTCOURSE = new TaughtCourse(EXPECTED_TAUGHTCOURSE_ENDDATE, EXPECTED_TAUGHTCOURSE_ID, EXPECTED_TAUGHTCOURSE_QUOTAS, EXPECTED_TAUGHTCOURSE_SESSION_DURATION, EXPECTED_TAUGHTCOURSE_STARTDATE, EXPECTED_TAUGHTCOURSE_TEACHING_DAY, EXPECTED_TAUGHTCOURSE_TOTAL_PRICE, EXPECTED_TAUGHTCOURSE_COURSE);

        //CLASSROOM
        public static int EXPECTED_CLASSROOM_MAXCAPACITY = 100;
        public static string EXPECTED_CLASSROOM_NAME = "G1.1";

        //ABSENCE
        public static DateTime EXPECTED_ABSENCE_DATE = DateTime.Now;

    }

}