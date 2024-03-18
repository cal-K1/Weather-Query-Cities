namespace WeatherQueoryApp
{
    public class Queries
    {
        public class QueryNames()
        {
            string city = Console.ReadLine().ToString();
        }

        public void AskCity()
        {
            Console.WriteLine("Which city do you want weather for?");
        }
    }


}
