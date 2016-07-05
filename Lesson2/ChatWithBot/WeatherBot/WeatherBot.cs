using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBot
{
    public class WeatherBot : IBot
    {
        public string Name { get; }

        public WeatherBot()
        {
            Name = "Marry";
        }

        public string Answer(string message)
        {
            message = message.ToLower();
            switch (message)
            {
                case "what's the weather today?":
                case "what's the weather on your side?":
                case "how do you like the weather today?":
                    return "It is very hot today... I cannot stand it anymore.";
                case "is it sunny?":
                case "is it rainy?":
                case "is it cloudy?":
                    return "It was, but not at the moment.";
                case "what kind of weather do you like?":
                case "any prefferences regarding the weather?":
                case "what's you favorite weather?":
                    return "I like when it's warm, cloudy and windy.";
                case "do you know about the weather for tomorrow?":
                case "what's the weather tomorrow?":
                    return "It's going to be rainy and cold as far as I know";
            }
            return "";
        }
    }
}
