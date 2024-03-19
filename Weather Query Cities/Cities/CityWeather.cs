using Weather_Query_Cities.Services;

namespace Weather_Query_Cities.Cities
{
    public class WeatherInfo
    {
        public static async Task Main(string[] args)
        {
            await WeatherService.GetWeather();
        }

        public static void DisplayWeatherInfo(int temperature, bool cloudCheck, bool rainCheck, DateTime sunrise, DateTime sunset)
        {
            Console.WriteLine($"\nTemperature: {temperature}°C");
            Console.WriteLine($"Cloudy: {WeatherService.CloudCheck(cloudCheck)}");
            Console.WriteLine($"Rain Today: {WeatherService.RainTodayCheck(rainCheck)}");
            Console.WriteLine($"Sunrise: {sunrise.TimeOfDay}");
            Console.WriteLine($"Sunset: {sunset.TimeOfDay} \n");
        }
    }
}

