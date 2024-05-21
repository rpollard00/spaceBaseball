namespace SpaceBaseball.WebAPI.Handlers;

public static class WeatherHandlers
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    internal static WeatherForecast[] WeatherForecastHandler()
    {
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55), Summaries[Random.Shared.Next(Summaries.Length)]))
            .ToArray();
        return forecast;
    }
}