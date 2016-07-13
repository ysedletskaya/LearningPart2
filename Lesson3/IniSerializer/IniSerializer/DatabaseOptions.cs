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

        [IniSection(ElementName = "owner")]
        [IniKey(ElementName = "organization")]
        public string OrganizationName { set; get; }

        [IniSection(ElementName = "database")]
        [IniKey(ElementName = "server")]
        public string Server { set; get; }

        [IniSection(ElementName = "database")]
        [IniKey(ElementName = "port")]
        public int Port { set; get; }

        [IniSection(ElementName = "database")]
        [IniKey(ElementName = "file")]
        public string File { set; get; }
    }
}
