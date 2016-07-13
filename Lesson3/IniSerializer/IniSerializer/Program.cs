using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IniSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseOptions dbConnection = new DatabaseOptions();

            IniSerializer serializer = new IniSerializer(typeof(DatabaseOptions));

            Stream stream = File.Open("DatabaseOptions.ini", FileMode.Create);

            using (TextWriter writer = new StreamWriter(stream))
            {
                serializer.Serialize(writer, dbConnection);
            }

            using (TextReader reader = new StreamReader(stream))
            {
                DatabaseOptions dbDeserealized = serializer.Deserialize(reader) as DatabaseOptions;
            }
        }
    }
}
