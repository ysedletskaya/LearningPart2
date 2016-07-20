using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public class Reader
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }

        public Reader(string name, string surname, int age = 20, string gender = "male")
        {
            Name = name;
            Surname = surname;
            FullName = string.Concat(name, " ", surname);
            Age = age;
            Gender = gender;
        }
    }
}
