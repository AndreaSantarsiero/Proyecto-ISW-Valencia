using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Absence : IGestAcaEntity
    {
        public Absence() { }

        public Absence(DateTime date)
        {
            this.Date = date;
        }

        public string GetName()
        {
            return string.Empty;
        }
    }
}
