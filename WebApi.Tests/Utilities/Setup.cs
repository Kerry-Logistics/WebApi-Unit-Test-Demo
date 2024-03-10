using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Controllers;
using WebApi.Service.Interface;

namespace WebApi.Tests.Utilities;

public class Setup
{
    private readonly IConfiguration _configuration;
    private readonly IService _service;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly Mock<ILogger<WeatherForecastController>> _mock_logger;
    public Mock<IService> _mock_service { get; set; }
    public WeatherForecastController _weatherForecastController { get; set; }
    
    public Setup()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "");
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true, reloadOnChange: true);
        
        _configuration = builder.Build();
        
        // mock
        _mock_service = new Mock<IService>();
        _service = _mock_service.Object;
        _mock_logger = new Mock<ILogger<WeatherForecastController>>();
        _logger = _mock_logger.Object;

        // real - integration test
        _weatherForecastController = new WeatherForecastController(_logger, _service);

        // database & caching setup
        // _dataSourceCollection = new DataSourceCollection();
        // _cachingCollection = new CachingCollection();
        // _configuration.Bind("DataSources", _dataSourceCollection);
        // _configuration.Bind("RedisCaching", _cachingCollection);
        // _dataConnectionFactory = new GenericDataConnectionFactory(_dataSourceCollection);
        // _redisCachingConnectionFactory = new RedisCachingConnectionFactory(_cachingCollection);
    }
}