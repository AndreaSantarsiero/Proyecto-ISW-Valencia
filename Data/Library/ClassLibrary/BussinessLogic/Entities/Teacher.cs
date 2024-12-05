using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Teacher : IGestAcaEntity
    {
        //constructor sin paràmetros
        public Teacher()
        {
            TaughtCourses = new List<TaughtCourse>();
        }

        //constructor con paràmetros
        public Teacher(string address, string id, string name, int zipCode, string Ssn) : base(address, id, name, zipCode)
        {
            this.Ssn = Ssn;

            TaughtCourses = new List<TaughtCourse>();
        }

        //metodo para verificar si el profesor puede impartir un nuevo curso
        public bool IsAvailableForNewTaughtCouse(TaughtCourse taughtCourse)
        {
            foreach (var taughtCourseAlreadyAssigned in this.TaughtCourses)
            {
                //mismo dia de la semana (lunes, martes ecc..) y el curso nuevo empleza antes que el curso viejo termina
                if (taughtCourseAlreadyAssigned.TeachingDay == taughtCourse.TeachingDay &&
                    taughtCourseAlreadyAssigned.EndDate >= taughtCourse.StartDateTime.Date)
                {
                    //overlaps1: new taughtCourse starts during the old one
                    if (taughtCourse.StartDateTime.TimeOfDay >= taughtCourseAlreadyAssigned.StartDateTime.TimeOfDay &&
                    taughtCourse.StartDateTime.TimeOfDay < taughtCourseAlreadyAssigned.StartDateTime.AddMinutes(taughtCourseAlreadyAssigned.SessionDuration).TimeOfDay)
                    {
                        return false;
                    }

                    //overlaps2: old taughtCourse starts during the new one
                    else if (taughtCourseAlreadyAssigned.StartDateTime.TimeOfDay >= taughtCourse.StartDateTime.TimeOfDay &&
                    taughtCourseAlreadyAssigned.StartDateTime.TimeOfDay > taughtCourse.StartDateTime.AddMinutes(taughtCourse.SessionDuration).TimeOfDay)
                    {
                        return false;
                    }
                }
            }

            //if we don't find overlaps with any of the taughtCourses that are already teached to that professor, then the professor is available
            return true;
        }
    }
}
