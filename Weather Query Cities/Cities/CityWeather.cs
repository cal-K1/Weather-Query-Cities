using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Metrics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather_Query_Cities.Cities
{
    public class WeatherInfo
    {
        public static async Task Main(string[] args)
        {
            await GetLondonWeather();
        }

        private static async Task GetLondonWeather()
        {
            string apiKey = "89cd960aa41028654097754fdccdb9ed";
            string city = "London";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Throw exception if HTTP error

                    string responseBody = await response.Content.ReadAsStringAsync();
                    ParseWeatherInfo(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        private static void ParseWeatherInfo(string responseBody)
        {
            // Parse JSON response
            JObject weatherData = JObject.Parse(responseBody);

            // Extract relevant information
            int temperature = (int)weatherData["main"]["temp"];
            bool isCloudy = ((string)weatherData["weather"][0]["main"]).Equals("Clouds", StringComparison.OrdinalIgnoreCase);
            bool isRainToday = ((string)weatherData["weather"][0]["main"]).Equals("Rain", StringComparison.OrdinalIgnoreCase);
            DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunrise"]).LocalDateTime;
            DateTime sunset = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunset"]).LocalDateTime;

            // Display weather information
            Console.WriteLine($"Temperature: {temperature}°C");
            Console.WriteLine($"Cloudy: {isCloudy}");
            Console.WriteLine($"Rain Today: {isRainToday}");
            Console.WriteLine($"Sunrise: {sunrise}");
            Console.WriteLine($"Sunset: {sunset}");
        }
    }
}

