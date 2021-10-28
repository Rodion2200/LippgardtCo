using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models
{
    class Patient
    {
        public string name;
        public string surname;
        public int age;
        public string status;

        public Patient(string name, string surname, int age, string status)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.status = status;
        }
    }
}
