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
            message = message.ToLower();
            switch (message)
            {
                case "hi":
                case "hello":
                case "hey":
                    return "Hello!";
                case "how are you?":
                case "what's up?":
                    return "I'm great! What about you?";
                case "buy":
                case "good buy":
                    return "Buy-buy, have a great day!";
                case "have a great day":
                case "have a great weekend":
                case "have a great evening":
                case "have a great week":
                    return "You too, we'll keep in touch!";
            }
            return "";
        }
    }
}
