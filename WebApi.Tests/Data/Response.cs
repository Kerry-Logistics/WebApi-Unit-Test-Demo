using System;
using System.Collections.Generic;

namespace WebApi.Tests.Data;

public class Response
{
    public static List<WeatherForecast> WeatherForecastsResponse { get; set; } = new List<WeatherForecast>
    {
        new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = -11,
            TemperatureF = 13,
            Summary = "Cool"
        }
    };
}