using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities
{
    public abstract partial class Person : IGestAcaEntity
    {
        //constructor sin paràmetros
        public Person() { }

        //constructor con paràmetros
        public Person(string address, string id, string name, int zipCode) 
        {
            this.Address = address;
            this.Id = id;
            this.Name = name;
            this.ZipCode = zipCode;
        }

        public string GetName()
        {
            return this.Name;
        }

        public override string ToString() {
            return "Nombre: " + this.Name +
                   "\r\nDni: " + this.Id +
                   "\r\nDirección: " + this.Address +
                   "\r\nCódigo postal: " + this.ZipCode;
        }
    }
}
