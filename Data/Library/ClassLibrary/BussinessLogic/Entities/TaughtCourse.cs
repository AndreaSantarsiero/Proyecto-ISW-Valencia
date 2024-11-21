using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class TaughtCourse
    {
        public TaughtCourse()
        {
            Enrollments = new List<Enrollment>();
            Teachers = new List<Teacher>();
        }

        public TaughtCourse(DateTime endDate, int id, int quotas, int sessionDuration, DateTime startDateTime, string teachingDay, int totalPrice, Course course)
        {
            EndDate = endDate;
            Id = id;
            Quotas = quotas;
            SessionDuration = sessionDuration;
            StartDateTime = startDateTime;
            TeachingDay = teachingDay;
            TotalPrice = totalPrice;
            Course = course;
            Enrollments = new List<Enrollment>();
            Teachers = new List<Teacher>();
        }

        public void SetClassroom(Classroom c)
        {
            this.Classroom = c;
        }

        public void AddTeacher(Teacher t)
        {
            this.Teachers.Add(t);
        }
    }
}
