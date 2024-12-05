using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Course: IGestAcaEntity
    {
        public Course()
        {
            TaughtCourses = new List<TaughtCourse>();
        }

        public Course(string description, string name)
        {
            Description = description;
            Name = name;

            TaughtCourses = new List<TaughtCourse>();
        }

        public string GetName()
        {
            return this.Name;
        }
    }
}
