using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            InitializeComponent();
            messages = new List<ChatMessage>();
            Assembly myAsm = Assembly.LoadFrom("bin\\DLLs\\");
        }

        private void addChatMessage(string text)
        {
            messages.Add(new ChatMessage(text));
            messageTextBox.Text = "";
            lbChatMessages.ItemsSource = messages;
            lbChatMessages.Items.Refresh();
        }

        private void getAnswer(string text)
        {
            string answer = null;
            messages.Add(new ChatMessage(answer));
            lbChatMessages.ItemsSource = messages;
            lbChatMessages.Items.Refresh();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            addChatMessage(textBoxMessage);
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
            }
        }
    }
}
