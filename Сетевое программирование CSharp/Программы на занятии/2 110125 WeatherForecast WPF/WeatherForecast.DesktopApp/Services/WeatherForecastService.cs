using System.Net.Http.Json;
using WeatherForecast.DesktopApp.Models;

namespace WeatherForecast.DesktopApp.Services;

public static class WeatherForecastService
{
    private const string Url = "http://localhost:5167/weatherforecast/";
    
    // сделали асинхронный перечислитель 
    public static IAsyncEnumerable<WeatherForecastDto?> GetWeatherForecastAsync(CancellationToken ct = default) 
        =>  App.HttpClient.GetFromJsonAsAsyncEnumerable<WeatherForecastDto?>(Url, ct);
        
}