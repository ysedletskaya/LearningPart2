using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BooksLibrary
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();         
            Library MyLib = new Library();
            MyLib.GenerateBooksFromFile("books.txt");
            MyLib.GenerateReaders("femalenames.txt", "malenames.txt", "surnames.txt", 10000);
            MyLib.GenerateBooksAssignment(6000);
            MyLib.XMLSerializeLibrary("DB.xml");


        }

        private void LoadXMLDB_Click(object sender, EventArgs e)
        {

        }
    }
}
