using BotSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        List<IBot> botObjs = null;

        public MainWindow()
        {
            InitializeComponent();
            messages = new List<ChatMessage>();
            botObjs = new List<IBot>();
            LoadDLLs();
        }

        public void LoadDLLs()
        {
            // Get all DLL names from \output\DLLs\
            string bothPath = Path.Combine(Directory.GetCurrentDirectory(), "DLLs");
            string[] dllFiles = Directory.GetFiles(bothPath, "*.dll");
            foreach (string dllPath in dllFiles)
            {
                // Load Bot library one by one from \bin\DLLs\
                Assembly myAsm = Assembly.LoadFrom(dllPath);

                // Get all DLL types and identify derived from IBot
                Type[] botTypes = myAsm.GetTypes();
                foreach (Type bot in botTypes)
                {
                    foreach (Type ibot in bot.GetInterfaces())
                    {
                        if (ibot.Name == "IBot")
                        {
                            // Add instance for all create bots to the list
                            botObjs.Add(Activator.CreateInstance(bot) as IBot);
                        }
                    }
                }
            }
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
            foreach (IBot obj in botObjs)
            {
                string answer = obj.Answer(text);
                string sender = obj.Name;
                 
                // If the Bot's answer returned is not empty - add it to Chat text box
                if (answer != "")
                {
                    addChatMessage(answer, sender);
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
