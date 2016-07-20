using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Reader> Readers { get; set; }
        public Dictionary<Reader,List<Book>> AssignedBooks { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Readers = new List<Reader>();
            AssignedBooks = new Dictionary<Reader, List<Book>>();
        }

        public void GenerateBooksFromFile(string filePath)
        {          
            List<string> bookStrings = new List<string>();
            FileHandling.ReadFromFile(filePath, out bookStrings);
            foreach (string book in bookStrings)
            {
                string author;
                Books.Add(new Book(SplitBookNameAndAuthor(book, out author), author));
            }
        }

        private string SplitBookNameAndAuthor(string bookStr, out string author)
        {
            int separatorStart = bookStr.IndexOf(" by ");
            string book = bookStr.Substring(0, separatorStart);
            author = bookStr.Substring(separatorStart + 4, bookStr.Length - (separatorStart + 4));
            return book;
        }

        public void GenerateReaders(string fileFemaleNames, string fileMaleNames, string filePathSurnames, int numOfReaders)
        {
            Random randomN = new Random();
            List<string> femaleNames = new List<string>();
            List<string> maleNames = new List<string>();
            List<string> surnameStrings = new List<string>();
            FileHandling.ReadFromFile(fileFemaleNames, out femaleNames);
            FileHandling.ReadFromFile(fileMaleNames, out maleNames);
            FileHandling.ReadFromFile(filePathSurnames, out surnameStrings);
            for (int i = 0; i < numOfReaders / 2; i++)
            {
                string femaleName = femaleNames[randomN.Next(femaleNames.Count - 1)];
                string surname = surnameStrings[randomN.Next(surnameStrings.Count - 1)];
                int age = randomN.Next(16, 100);
                if (!Readers.Contains(new Reader(femaleName, surname, age, "female")))
                {
                    Readers.Add(new Reader(femaleName, surname, age, "female"));
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < numOfReaders / 2; i++)
            {
                string maleName = maleNames[randomN.Next(maleNames.Count - 1)];
                string surname = surnameStrings[randomN.Next(surnameStrings.Count - 1)];
                int age = randomN.Next(16, 100);
                if (!Readers.Contains(new Reader(maleName, surname, age, "male")))
                {
                    Readers.Add(new Reader(maleName, surname, age, "male"));
                }
                else
                {
                    i--;
                }
            }
        }
        
        public void GenerateBooksAssignment(int numOfAssignments)
        {

        }
    }
}
