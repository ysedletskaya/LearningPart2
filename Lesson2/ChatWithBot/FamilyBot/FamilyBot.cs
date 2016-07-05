using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBot
{
    public class FamilyBot : IBot
    {
        public string Name { get; }        

        public FamilyBot()
        {
            Name = "Steve";
        }

        public string Answer(string message)
        {
            message = message.ToLower();
            switch (message)
            {
                case "how is your family?":
                case "how is your wife?":
                case "how are your kids?":
                    return "Fine, thanks!";
                case "do you have family?":
                case "do you have wife?":
                case "do you have kids?":
                    return "Yes, I do!";
                case "how many kids do you have?":
                case "how big is your family?":
                    return "I have 5 kids!";
                case "how old are your kids?":
                case "how old are them?":
                    return "12, 9, 6, 3, 1 years.";
                case "what are the names of your kids?":
                case "what are their names?":
                    return "Susan, Bob, Chase, Glan and John.";
                case "what's your wife's name?":
                    return "Her nam is Victoria.";
            }
            return "";
        }
    }
}
