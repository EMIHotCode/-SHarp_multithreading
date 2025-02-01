using System.Collections.ObjectModel;
using System.Reactive;
using Microsoft.AspNetCore.SignalR.Client;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SignalR_Chat.Client.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private HubConnection? _hubConnection;
    [Reactive] public string? Message { get; set; }
    public ObservableCollection<string> OutputMessages { get; } = [];
    public ReactiveCommand<Unit, Unit> CommandSend { get; }

    public MainWindowViewModel()
    {
        var hubBuilder = new HubConnectionBuilder();
        hubBuilder.WithUrl("http://localhost:5046/chat");

        _hubConnection = hubBuilder.Build();
        _hubConnection.StartAsync();
        
        _hubConnection.On<string>("ReceiveMessage", (message) =>
        {
            OutputMessages.Add(message);
        });

        CommandSend = ReactiveCommand.CreateFromTask(async () =>
        {
            await _hubConnection.InvokeAsync("SendMessage", Message);
        });
    }
}