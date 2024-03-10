namespace WebApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF
        {
            get => 32 + (int)(TemperatureC / 0.5556);
            set => TemperatureC = (int)((value - 32) * 0.5556);
        }

        public string? Summary { get; set; }
    }
}
