using System.Text.RegularExpressions;
using GetWeather.API;
using System.Net;

var http = new HttpClient();  // Для отправки HTTP-запросов в .NET применяется класс HttpClient
//  var response = await http.GetAsync   
// приложение нужно переделывать под WebAPI проект



while(true)
{
    await Task.Run(async () =>
    {
        var response =
            await http.GetAsync(
                "https://www.meteoservice.ru/weather/overview/nizhniy-novgorod"); // получаем ответ от запроса 

        Location myLocation = new Location();

        if (response.IsSuccessStatusCode)
        {
            var httpPageText = response.Content.ReadAsStringAsync();
            myLocation.City = new Regex("(?:<meta.*?name=\"keywords\".*?)(.*?)(?:\\/>)").Match(await httpPageText)
                .Groups[0].Value;
            myLocation.Temperature = new Regex("(<span.*?class=\"value\">)(.*?)(<\\/span>)").Match(await httpPageText)
                .Groups[0].Value;

            string[] wordsTagCity = myLocation.City.Split(',');
            string[] wordsTagTemprature = myLocation.Temperature.Split('<', '>');

            myLocation.City = wordsTagCity[2];
            myLocation.Temperature = wordsTagTemprature[2];
        }

        Console.WriteLine($"\n\nВаш город: {myLocation.City}");
        Console.WriteLine($"Температура за окном: {myLocation.Temperature}С");
        await Task.Delay(1000);
    });

}



/*
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
*/


