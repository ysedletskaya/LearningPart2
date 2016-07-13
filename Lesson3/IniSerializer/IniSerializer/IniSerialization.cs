using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private Type type;

        public IniSerializer(Type type)
        {
            this.type = type;
        }

        public void Serialize(TextWriter writer, Object obj)
        {
            PropertyInfo[] props = type.GetProperties();            
            foreach (PropertyInfo prop in props)
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(prop);
                foreach (Attribute attr in attrs)
                {
                    string attrValue = attr.GetType().GetProperty("ElementName").GetValue(attr) as string;
                    if (attr.GetType().Equals(typeof(IniSectionAttribute)))
                    {                        
                        writer.WriteLine("[{0}]", attrValue);
                    }
                    if (attr.GetType().Equals(typeof(IniKeyAttribute)))
                    {
                        writer.WriteLine("{0}={1}", attrValue, prop.GetValue(obj));
                    }
                }
            }
        }

        public object Deserialize(TextReader reader)
        {
            string line = reader.ReadLine();
            string nextLine = null;
            object obj = Activator.CreateInstance(type);
            if (line != null)
            {
                do
                {
                    IniSectionAttribute secAttr = ParseSectionAttribute(line);
                    if (secAttr != null)
                    {
                        nextLine = reader.ReadLine();
                        PropertyInfo prop = SetProperty(obj, nextLine);
                        IniSectionAttribute tempSecAttr = (IniSectionAttribute)Attribute.GetCustomAttribute(prop, typeof(IniSectionAttribute));
                        tempSecAttr = secAttr;
                    }
                    else
                    {
                        PropertyInfo prop = SetProperty(obj, line);
                    }
                    line = reader.ReadLine();
                }
                while (line != null);
            }
            return obj;
        }

        private PropertyInfo SetProperty(object obj, string line)
        {
            IniKeyAttribute keyAttr = ParseKeyAttribute(line);
            string propertyValue = ParsePropertyValue(line);
            PropertyInfo prop = null;
            if (propertyValue != null)
            {
                prop = type.GetProperty(MakeFirstLetterUpperCase(keyAttr.ElementName));
                string propType = prop.PropertyType.Name;
                if (propType.Contains("Int"))
                {
                    prop.SetValue(obj, Convert.ToInt16(propertyValue));
                }
                if (propType.Equals("Double"))
                {
                    prop.SetValue(obj, Convert.ToDouble(propertyValue));
                }
                if (propType.Equals("String"))
                {
                    prop.SetValue(obj, propertyValue);
                }
                IniKeyAttribute tempKeyAttr = (IniKeyAttribute)Attribute.GetCustomAttribute(prop, typeof(IniKeyAttribute));
                tempKeyAttr = keyAttr;
            }
            return prop;
        }

        private string MakeFirstLetterUpperCase(string str)
        {
            string tmp = str.ToUpper();
            return tmp[0] + str.Remove(0,1);
        }

        private IniSectionAttribute ParseSectionAttribute(string line)
        {            
            string result = null;
            if (line.Contains("["))
            {
                string[] tmp = line.Split('[');
                result = tmp[tmp.Length - 1];
                tmp = result.Split(']');
                result = tmp[0];
                IniSectionAttribute attr = new IniSectionAttribute();
                attr.ElementName = result;
                return attr;
            }
            return null;
        }

        private IniKeyAttribute ParseKeyAttribute(string line)
        {
            string result = null;
            if (line.Contains("="))
            {
                string[] tmp = line.Split('=');
                result = tmp[0];
                IniKeyAttribute attr = new IniKeyAttribute();
                attr.ElementName = result;
                return attr;
            }
            return null;
        }

        private string ParsePropertyValue(string line)
        {
            string result = null;
            if (line.Contains("="))
            {
                string[] tmp = line.Split('=');
                result = tmp[tmp.Length - 1];
            }
            return result;
        }
    }
}
