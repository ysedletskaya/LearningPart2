using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLibrary
{
    public static class FileHandling
    {
        public static bool MissingFileCreation(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return true;
            }
            return false;
        }

        public static void ReadFromFile(string filePath, out List<string> fileContent)
        {
            fileContent = new List<string>();
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                string fileLine = null;
                while ((fileLine = fileReader.ReadLine()) != null)
                {
                    fileContent.Add(fileLine);
                }
            }
        }

        public static void WriteToFile(List<string> fileContent, string filePath)
        {
            using (StreamWriter fileWriter = new StreamWriter(filePath))
            {
                foreach (string fileLine in fileContent)
                {
                    fileWriter.WriteLine(fileLine);
                }
            }
        }
    }
}