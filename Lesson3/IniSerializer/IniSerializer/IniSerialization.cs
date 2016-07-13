using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IniSerializer
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class IniSectionAttribute : Attribute
    {
        public string ElementName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class IniKeyAttribute : Attribute
    {
        public string ElementName { get; set; }
    }

    public class IniSerializer
    {
        public IniSerializer(Type type)
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(type);

        }

        public void Serialize(TextWriter writer, Object obj)
        {
        }

        public object Deserialize(TextReader reader)
        {
            return null;
        }

    }
}
