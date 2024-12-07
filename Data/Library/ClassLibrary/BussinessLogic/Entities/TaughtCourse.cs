using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class TaughtCourse : IGestAcaEntity
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

        public void SetClassroom(Classroom classroom)
        {
            this.Classroom = classroom;
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            this.Enrollments.Add(enrollment);
        }

        public string GetName() 
        { 
            return this.Course.GetName(); 
        }

        public bool ClassroomFull()
        {
            if (this.Classroom != null && this.Classroom.MaxCapacity <= this.Enrollments.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Nombre curso: " + this.Course.Name +
                   "\r\nFecha de inicio: " + this.StartDateTime.Date.ToString("dd/MM/yyyy") +
                   "\r\nFecha de finalización: " + this.EndDate.ToString("dd/MM/yyyy") +
                   "\r\nHora de comienzo: " + this.StartDateTime.TimeOfDay.ToString(@"hh\:mm") +
                   "\r\nHora de finalización: " + this.StartDateTime.AddMinutes(this.SessionDuration).TimeOfDay.ToString(@"hh\:mm");
        }
    }
}
