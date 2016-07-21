using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BooksLibrary
{
    public class Library
    {
        public Dictionary<Reader, List<Book>> AssignedBooks { get; set; }

        public List<Book> Books { get; set; }

        public List<Reader> Readers { get; set; }

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

        private void FillReadersFromLists(List<string> names, List<string> surnames, string gender, int numOfRepeats)
        {
            Random randomN = new Random();
            for (int i = 0; i < numOfRepeats; i++)
            {
                string name = names[randomN.Next(names.Count - 1)];
                string surname = surnames[randomN.Next(surnames.Count - 1)];
                int age = randomN.Next(16, 100);
                if (!Readers.Contains(new Reader(name, surname, age, gender)))
                {
                    Readers.Add(new Reader(name, surname, age, gender));
                }
                else
                {
                    i--;
                }
            }
        }

        public void GenerateReaders(string fileFemaleNames, string fileMaleNames, string filePathSurnames, int numOfReaders)
        {            
            List<string> femaleNames = new List<string>();
            List<string> maleNames = new List<string>();
            List<string> surnameStrings = new List<string>();
            FileHandling.ReadFromFile(fileFemaleNames, out femaleNames);
            FileHandling.ReadFromFile(fileMaleNames, out maleNames);
            FileHandling.ReadFromFile(filePathSurnames, out surnameStrings);
            FillReadersFromLists(femaleNames, surnameStrings, "female", numOfReaders / 2);
            FillReadersFromLists(maleNames, surnameStrings, "male", numOfReaders / 2);
        }
        
        public void GenerateBooksAssignment(int numOfAssignments)
        {
            Random randomN = new Random();
            for (int i = 0; i < numOfAssignments; i++)
            {
                Reader randomReader = Readers[randomN.Next(Readers.Count - 1)];
                Book randomBook = Books[randomN.Next(Books.Count - 1)];
                if (!AssignedBooks.ContainsKey(randomReader))
                {
                    AssignedBooks.Add(randomReader, new List<Book> { randomBook });                   
                }
                else if (AssignedBooks.ContainsKey(randomReader))
                {
                    List<Book> booksOfRandomReader = new List<Book>();
                    AssignedBooks.TryGetValue(randomReader, out booksOfRandomReader);
                    if ((booksOfRandomReader != null) && !booksOfRandomReader.Contains(randomBook))
                    {
                        booksOfRandomReader.Add(randomBook);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        public void XMLSerializeLibrary(string xmlFileName)
        {
            XElement root = new XElement("Library");

            foreach (var item in AssignedBooks)
            {
                XElement dataItem = new XElement("DataItem");
                XElement reader = new XElement("Reader");
                reader.Add(new XElement("FullName", item.Key.FullName));
                reader.Add(new XElement("Age", item.Key.Age));
                reader.Add(new XElement("Gender", item.Key.Gender));
                dataItem.Add(reader);
                XElement books = new XElement("Books");
                item.Value.ForEach(x => books.Add(new XElement("Book", new XElement("Name", x.Name), new XElement("Author", x.Author))));
                dataItem.Add(books);
                root.Add(dataItem);
            }
            root.WriteTo(XmlWriter.Create(xmlFileName));
        }
    }
}
