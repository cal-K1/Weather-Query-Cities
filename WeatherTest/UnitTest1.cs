using FluentAssertions;
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

    }
}