var builder = WebApplication.CreateBuilder(args); // сборщик приложения

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // добавляются сервисы. Сейчас не добавляются можно удалить

var app = builder.Build();  // собирается 

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())  // если находимся в режиме разработчика присходит сопоставление маппирование. Можно удалить пока не пользуемся
{
    app.MapOpenApi(); 
}

app.UseHttpsRedirection();  //  в других случаяях идет переход перенаправление на HTTPS

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
// основная часть сервера
app.MapGet("/weatherforecast", () =>  // напоминает событие и обработчик события 
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
// app.MapPost(); можно реализовать 
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}