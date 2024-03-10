using System.Linq;
using JetBrains.Annotations;
using Moq;
using WebApi.Controllers;
using WebApi.Controllers.Interface;
using WebApi.Tests.Data;
using WebApi.Tests.Utilities;
using Xunit;

namespace WebApi.Tests.Controllers;

[TestSubject(typeof(WeatherForecastController))]
public class WeatherForecastControllerTest
{
    private readonly Setup _setup;
    private readonly IWeatherForecastController _weatherForecastController_mock;
    private Mock<IWeatherForecastController> _mock_weatherForecastController;

    public WeatherForecastControllerTest()
    {
        _setup = new Setup();
        _mock_weatherForecastController = new Mock<IWeatherForecastController>();
        _weatherForecastController_mock = _mock_weatherForecastController.Object;
    }
    
    [Fact]
    public void GetWeatherForecast()
    {
        // arrange
        _mock_weatherForecastController
            .Setup(m => m.Get())
            .Returns(Response.WeatherForecastsResponse);
        
        // act
        var result = _weatherForecastController_mock
            .Get();
        
        // assert
        Assert.True(result.Any());
    }
    
    [Fact]
    public void SetWeatherForecast_FailedCase()
    {
        // arrange
        _setup._mock_service
            .Setup(m => m.ValidateTemp(
                -1))
            .Returns("invalid");
        
        // act
        var result = _setup._weatherForecastController
            .Set(-1);
        
        // assert
        Assert.True(result == null);
    }
    
    [Fact]
    public void SetWeatherForecast_SuccessCase()
    {
        // arrange
        _setup._mock_service
            .Setup(m => m.ValidateTemp(
                It.IsAny<int>()))
            .Returns("valid");
        
        // act
        var result = _setup._weatherForecastController
            .Set(It.IsAny<int>());
        
        // assert
        Assert.True(result == "valid");
    }
}