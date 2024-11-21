using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Classroom
    {
        public Classroom()
        {
            TaughtCourses = new List<TaughtCourse>();
        }

        public Classroom(int maxCapacity, string name)
        {
            MaxCapacity = maxCapacity;
            Name = name;

            TaughtCourses = new List<TaughtCourse>();
        }

        //metodo para verificar si el aula se puede asignar a un nuevo curso
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

            //if we don't find overlaps with any of the taughtCourses that are already assigned to that class, then the class is available
            return true;
        }
    }
}
