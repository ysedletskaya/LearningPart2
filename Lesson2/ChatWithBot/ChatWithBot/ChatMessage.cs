using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatWithBot
{
    class ChatMessage
    {
        public string messageText { get; }
        public string senderName { get; }

        public ChatMessage(string text)
        {
            messageText = text;
            senderName = "Me";
        }

        public ChatMessage(string text, string sender)
        {
            messageText = text;
            senderName = sender;
        }
    }
}
