using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Student : Person
    {
        public string IBAN { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
