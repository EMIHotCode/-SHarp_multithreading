using Microsoft.AspNetCore.SignalR.Client;

var hubBuilder = new HubConnectionBuilder();
hubBuilder.WithUrl("http://localhost:5046/chat");

var hubConnection = hubBuilder.Build();
await hubConnection.StartAsync();

hubConnection.On<string>("ReceiveMessage", (message) =>
{
    Console.WriteLine($"{message}");
});
Console.ReadKey();