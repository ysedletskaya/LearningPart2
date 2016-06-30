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
            switch (message)
            {
                case "What's the weather today?":
                case "What's the weather on your side?":
                case "How do you like the weather today?":
                    return "It is very hot today... I cannot stand it anymore.";
                case "Is it sunny?":
                case "Is it rainy?":
                case "Is it cloudy?":
                    return "It was, but not at the moment.";
                case "What kind of weather do you like?":
                case "Any prefferences regarding the weather?":
                case "What's you favorite weather?":
                    return "I like when it's warm, cloudy and windy.";
                case "Do you know about the weather for tomorrow?":
                case "What's the weather tomorrow?":
                    return "It's going to be rainy and cold as far as I know";
            }
            return "";
        }
    }
}
