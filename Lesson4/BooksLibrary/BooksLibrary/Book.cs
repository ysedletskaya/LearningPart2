using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public bool IsAssigned { get; private set; }
        public Reader Reader { get; private set; }

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
            IsAssigned = false;
            Reader = null;
        }

        public void Assign(string bookName, Reader reader)
        {
            if (reader != null)
            {
                IsAssigned = true;
                Reader = reader;
            }
        }

        public void Return()
        {
            IsAssigned = false;
            Reader = null;
        }
    }
}
