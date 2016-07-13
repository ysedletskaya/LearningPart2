using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniSerializer
{
    public class DatabaseOptions
    {
        [IniSection(ElementName = "owner")]
        [IniKey(ElementName = "name")]
        public string Name { set; get; }

        [IniKey(ElementName = "organization")]
        public string Organization { set; get; }

        [IniSection(ElementName = "database")]
        [IniKey(ElementName = "server")]
        public string Server { set; get; }

        [IniKey(ElementName = "port")]
        public int Port { set; get; }

        [IniKey(ElementName = "file")]
        public string File { set; get; }

        [IniKey(ElementName = "coefficient")]
        public double Coefficient { set; get; }

    }
}
