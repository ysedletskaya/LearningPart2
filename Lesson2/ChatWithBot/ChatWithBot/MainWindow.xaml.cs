using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatWithBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ChatMessage> messages = null;
        string textBoxMessage = null;
        string lastMessage = null;

        public MainWindow()
        {
            InitializeComponent();
            messages = new List<ChatMessage>();

        }

        public static string GetAsmTypeName(string file)
        {
            string[] filename = file.Split('\\');
            string[] typename = filename[filename.Length - 1].Split('.');
            return typename[0];
        }

        private void addChatMessage(string text, string sender = "Me")
        {
            messages.Add(new ChatMessage(text, sender));
            lastMessage = text;
            messageTextBox.Text = "";
            lbChatMessages.ItemsSource = messages;
            lbChatMessages.Items.Refresh();
        }

        private void getAnswer(string text)
        {
            // Get all DLL names from \bin\DLLs\
            string[] dllFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (string dllPath in dllFiles)
            {
                if (!dllPath.Contains("SDK"))
                {
                    // Load Bot library one by one from \bin\DLLs\
                    Assembly myAsm = Assembly.LoadFrom(dllPath);
                    
                    // Get DLL's name and get assemly Type using it
                    string asmName = GetAsmTypeName(dllPath);
                    Type bot = myAsm.GetType(string.Concat(asmName, ".", asmName));
                    
                    // Call Bot's 'Answer' method and get Bot's 'Name' property
                    object obj = Activator.CreateInstance(bot);
                    MethodInfo method = bot.GetMethod("Answer");
                    string answer = Convert.ToString(method.Invoke(obj, new object[] { text }));
                    PropertyInfo name = bot.GetProperty("Name");
                    string sender = Convert.ToString(name.GetValue(obj));
                    
                    // If the Bot's answer returned is not empty - add it to Chat text box
                    if (answer != "")
                    {
                        addChatMessage(answer, sender);
                    }
                }
            }
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            addChatMessage(textBoxMessage);
            getAnswer(lastMessage);
        }

        private void messageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBoxMessage = messageTextBox.Text;
        }

        private void messageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                addChatMessage(textBoxMessage);
                getAnswer(lastMessage);
            }
        }
    }
}
