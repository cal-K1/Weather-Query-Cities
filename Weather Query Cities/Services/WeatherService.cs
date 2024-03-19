using Newtonsoft.Json.Linq;
using Weather_Query_Cities.Cities;

namespace Weather_Query_Cities.Services
{
    public class WeatherService
    {
        public static async Task GetWeather()
        {
            while (true)
            {
                // Environment variable in place of API key
                string city = GetCity();
                string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("Error: OPENWEATHERMAP_API_KEY environment variable is not set.");
                    return;
                }

                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        response.EnsureSuccessStatusCode(); // Throw exception if HTTP error
                        string responseBody = await response.Content.ReadAsStringAsync();
                        await FormatWeatherInfo(responseBody);
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }
            }
        }

        public static async Task FormatWeatherInfo(string responseBody)
        {
            // Parse JSON response
            JObject weatherData = JObject.Parse(responseBody);

            // Extract relevant information
            int temperature = (int)weatherData["main"]["temp"];
            bool cloudCheck = ((string)weatherData["weather"][0]["main"]).Equals("Clouds", StringComparison.OrdinalIgnoreCase);
            bool rainCheck = ((string)weatherData["weather"][0]["main"]).Equals("Rainy", StringComparison.OrdinalIgnoreCase);
            DateTime sunrise = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunrise"]).LocalDateTime;
            DateTime sunset = DateTimeOffset.FromUnixTimeSeconds((long)weatherData["sys"]["sunset"]).LocalDateTime;

            WeatherInfo.DisplayWeatherInfo(temperature, cloudCheck, rainCheck, sunrise, sunset);
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

        public static string GetCity()
        {
            Console.WriteLine("Enter City: ");
            return Console.ReadLine();
        }
    }
}

