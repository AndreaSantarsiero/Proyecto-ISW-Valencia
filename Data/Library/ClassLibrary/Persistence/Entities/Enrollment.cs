using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Enrollment
    {
        public DateTime? CancellationDate { get; set; }

        public DateTime EnrollmentDate { get; set; }

        [Key]
        public int Id { get; set; }

        public bool UniquePayment { get; set; }


        [Required]
        public virtual Student Student { get; set; }
        [Required]
        public virtual TaughtCourse TaughtCourse { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
