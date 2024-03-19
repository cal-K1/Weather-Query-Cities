using FluentAssertions;
using Weather_Query_Cities.Cities;
using Weather_Query_Cities.Services;

namespace WeatherTest
{
    public class UnitTest1
    {
        [Fact]
        public void WeatherService_CloudCheck_ReturnsString()
        {
            // Arrange
            bool cloudCheckFalse = false;
            bool cloudCheckTrue = true;

            // Act
            WeatherService.CloudCheck(cloudCheckFalse);
            WeatherService.CloudCheck(cloudCheckTrue);

            // Assert
            WeatherService.CloudCheck(cloudCheckFalse).ToString().Should().Be("No");
            WeatherService.CloudCheck(cloudCheckTrue).ToString().Should().Be("Yes");
        }

        [Fact]
        public void WeatherService_RainTodayCheck_ReturnsString()
        {
            // Arrange
            bool rainCheckFalse = false;
            bool rainCheckTrue = true;

            // Act
            WeatherService.RainTodayCheck(rainCheckFalse);
            WeatherService.RainTodayCheck(rainCheckTrue);

            // Assert
            WeatherService.RainTodayCheck(rainCheckFalse).ToString().Should().Be("No");
            WeatherService.RainTodayCheck(rainCheckTrue).ToString().Should().Be("Yes");
        }

        [Fact]
        public async Task WeatherService_FormatWeatherInfo_IsTask()
        {
            // Arrange

            double temperature = 12.65;
            bool cloudCheck = true;
            bool rainCheck = false;
            DateTime sunrise = new DateTime(2024, 3, 19, 6, 4, 46);
            DateTime sunset = new DateTime(2024, 3, 19, 18, 11, 35);

            string responseBody = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":12.65,\"feels_like\":12.19,\"temp_min\":10.95,\"temp_max\":13.99,\"pressure\":1016,\"humidity\":85},\"visibility\":10000,\"wind\":{\"speed\":4.63,\"deg\":210},\"clouds\":{\"all\":100},\"dt\":1710856764,\"sys\":{\"type\":2,\"id\":2075535,\"country\":\"GB\",\"sunrise\":1710828286,\"sunset\":1710871895},\"timezone\":0,\"id\":2643743,\"name\":\"London\",\"cod\":200}";

            // Act
            await WeatherService.FormatWeatherInfo(responseBody);

            // Assert
            temperature.Should().Be(12.65);
            cloudCheck.Should().Be(true);
            rainCheck.Should().Be(false); 
            sunrise.Should().Be(new DateTime(2024, 03, 19, 6, 04, 46)); 
            sunset.Should().Be(new DateTime(2024, 03, 19, 18, 11, 35)); 
        }
    }
}