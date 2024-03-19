using Weather_Query_Cities.Services;

namespace Weather_Query_Cities.Cities
{
    public class WeatherInfo
    {
        public static async Task Main(string[] args)
        {
            await WeatherService.GetWeather();
        }

        public static string GetCity()
        {
            Console.WriteLine("Enter City: ");
            string city = Console.ReadLine();
            return city;
        }
    }
}

