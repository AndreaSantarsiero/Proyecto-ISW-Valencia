﻿using System;
using System.Collections.Generic;

namespace GestAca.Entities
{
    public partial class Enrollment: IGestAcaEntity
    {
        public Enrollment()
        {
            Absences = new List<Absence>();
        }

        public Enrollment(DateTime enrollmentDate, bool uniquePayment, Student student, TaughtCourse taughtCourse)
        {
            EnrollmentDate = enrollmentDate;
            UniquePayment = uniquePayment;
            Student = student;
            TaughtCourse = taughtCourse;
            Absences = new List<Absence>();
        }
        public string GetName()
        {
            return string.Empty;
        }
    }
}
