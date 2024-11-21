using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class TaughtCourse
    {
        public DateTime EndDate { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None), Key()]
        public int Id { get; set; }
        public int Quotas { get; set; }
        public int SessionDuration { get; set; }
        public DateTime StartDateTime { get; set; }
        public string TeachingDay { get; set; }
        public int TotalPrice { get; set; }
        
        [Required]
        public virtual Course Course { get; set; }

        public virtual Classroom Classroom {get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}
