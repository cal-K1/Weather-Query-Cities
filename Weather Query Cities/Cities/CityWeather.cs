using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Query_Cities.Cities
{
    public struct WeatherInfo
    {
        public int Temperature { get; } // Temperature in degrees Celsius
        public bool IsCloudy { get; }   // Indicates whether it's cloudy
        public bool IsRainToday { get; } // Indicates whether it's raining today
        public DateTime Sunrise { get; } // Sunrise time
        public DateTime Sunset { get; }  // Sunset time

        // Constructor to initialize properties
        public WeatherInfo(int temperature, bool isCloudy, bool isRainToday, DateTime sunrise, DateTime sunset)
        {
            Temperature = temperature;
            IsCloudy = isCloudy;
            IsRainToday = isRainToday;
            Sunrise = sunrise;
            Sunset = sunset;
        }

        public WeatherInfo London()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Leeds()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Wakefiled()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Edinburgh()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Brussels()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Munich()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Dortmund()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Berlin()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }

        public WeatherInfo Geneva()
        {
            int temperature = 10;
            bool isCloudy = true;
            bool isRainToday = true;
            DateTime sunrise = DateTime.Parse("06:30 AM");
            DateTime sunset = DateTime.Parse("05:00 PM");

            // Return a new instance of WeatherInfo with the fetched data
            return new WeatherInfo(temperature, isCloudy, isRainToday, sunrise, sunset);
        }
    }
}

