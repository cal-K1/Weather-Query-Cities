﻿using Newtonsoft.Json.Linq;
using Weather_Query_Cities.Cities;

namespace Weather_Query_Cities.Services
{
    internal class WeatherService
    {
        public static async Task GetWeather()
        {
            while (true)
            {
                string city = WeatherInfo.GetCity();
                string apiKey = "89cd960aa41028654097754fdccdb9ed";
                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        response.EnsureSuccessStatusCode(); // Throw exception if HTTP error

                        string responseBody = await response.Content.ReadAsStringAsync();
                        await ParseWeatherInfo(responseBody);
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
        }

        public static async Task ParseWeatherInfo(string responseBody)
        {
            // Parse JSON response
            JObject weatherData = JObject.Parse(responseBody);

            // Extract relevant information
            int temperature = (int)weatherData["main"]["temp"];
            bool cloudCheck = ((string)weatherData["weather"][0]["main"]).Equals("Clouds", StringComparison.OrdinalIgnoreCase);
            bool rainCheck = ((string)weatherData["weather"][0]["main"]).Equals("Rain", StringComparison.OrdinalIgnoreCase);
            DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunrise"]).LocalDateTime;
            DateTime sunset = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunset"]).LocalDateTime;

            Console.WriteLine($"\nTemperature: {temperature}°C");
            Console.WriteLine($"Cloudy: {CloudCheck(cloudCheck)}");
            Console.WriteLine($"Rain Today: {RainTodayCheck(rainCheck)}");
            Console.WriteLine($"Sunrise: {sunrise}");
            Console.WriteLine($"Sunset: {sunset} \n");
        }

        public static string CloudCheck(bool cloudCheck)
        {
            string isCloudy;
            if (cloudCheck)
            {
                isCloudy = "Yes";
            }
            else
            {
                isCloudy = "No";
            }
            return isCloudy;
        }

        public static string RainTodayCheck(bool rainCheck)
        {
            string isRainyToday;
            if (rainCheck)
            {
                isRainyToday = "Yes";
            }
            else
            {
                isRainyToday = "No";
            }
            return isRainyToday;
        }
    }
}
