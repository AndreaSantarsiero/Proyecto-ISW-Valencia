using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public partial class Student
    {
        //constructor sin paràmetros
        public Student() 
        { 
            Enrollments = new List<Enrollment>();
        }

        //constructor con paràmetros
        public Student(string address, string id, string name, int zipCode, string IBAN):base(address, id, name, zipCode) 
        {
            this.IBAN = IBAN;

            Enrollments = new List<Enrollment>();
        }
    }
}
