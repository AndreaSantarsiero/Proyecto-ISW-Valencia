﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace GestAca.Entities
{
    public partial class Absence
    {
        public DateTime Date { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
