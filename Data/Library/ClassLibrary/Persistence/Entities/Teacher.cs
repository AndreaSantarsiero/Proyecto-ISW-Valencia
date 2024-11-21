using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Teacher : Person
    {
        public string Ssn { get; set; }

        public virtual ICollection<TaughtCourse> TaughtCourses { get; set; }
    }
}
