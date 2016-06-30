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
            switch (message)
            {
                case "How is your family?":
                case "How is your wife?":
                case "How are your kids?":
                    return "Fine, thanks!";
                case "Do you have family?":
                case "Do you have wife?":
                case "Do you have kids?":
                    return "Yes, I do!";
                case "How many kids do you have?":
                case "How big is your family?":
                    return "I have 5 kids!";
                case "How old are your kids?":
                case "How old are them?":
                    return "12, 9, 6, 3, 1 years.";
                case "What are the names of your kids?":
                case "What are their names?":
                    return "Susan, Bob, Chase, Glan and John.";
                case "What's your wife's name?":
                    return "Her nam is Victoria.";
            }
            return "";
        }
    }
}
