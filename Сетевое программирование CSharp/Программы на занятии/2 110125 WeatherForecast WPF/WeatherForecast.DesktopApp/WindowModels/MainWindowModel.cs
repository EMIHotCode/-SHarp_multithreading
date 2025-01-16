using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using ReactiveUI;
using WeatherForecast.DesktopApp.Models;
using WeatherForecast.DesktopApp.Services;

namespace WeatherForecast.DesktopApp.WindowModels;

public class MainWindowModel : WindowModelBase
{
    public ObservableCollection<WeatherForecastDto> WeatherForecasts { get; } = [];

    public ReactiveCommand<Unit, Unit> CommandRefresh { get; }

    public MainWindowModel()
    {
        CommandRefresh = ReactiveCommand.CreateFromTask(async () =>
        {
            try
            {
                WeatherForecasts.Clear();
                
                var weatherForecasts = WeatherForecastService.GetWeatherForecastAsync();
                await foreach (var weatherForecast in weatherForecasts)
                {
                    if (weatherForecast is not null)
                    {
                        WeatherForecasts.Add(weatherForecast);
                    }
                }
            }
            catch (Exception e) // выдавать ошибку если сервер не запущен
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
    }
}