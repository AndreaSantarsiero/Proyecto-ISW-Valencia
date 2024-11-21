using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Absence
    {
        public Absence() { }

        public Absence(DateTime date)
        {
            this.Date = date;
        }
    }
}
