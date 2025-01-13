using System.Net.Http;
using System.Windows;

namespace WeatherForecast.DesktopApp;


public partial class App : Application
{
    public static HttpClient HttpClient { get; } = new();
}