using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingsBot
{
    public class GreetingsBot : IBot
    {
        public string Name { get; }

        public GreetingsBot()
        {
            Name = "Artur";
        }

        public string Answer(string message)
        {
            switch (message)
            {
                case "Hi":
                case "Hello":
                case "Hey":
                    return "Hello!";
                case "How are you?":
                case "What's up?":
                    return "I'm great! What about you?";
                case "Buy":
                case "Good buy":
                    return "Buy-buy, have a great day!";
                case "Have a great day":
                case "Have a great weekend":
                case "Have a great evening":
                case "Have a great week":
                    return "You too, we'll keep in touch!";
            }
            return "";
        }
    }
}
