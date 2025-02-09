﻿using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Reactive;
using System.Text;
using System.Text.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TCP_Chat.Client;

public class MainWindowViewModel : ViewModelBase
{
    private Socket _server;
    private NetworkStream _networkStream;
    
    public ObservableCollection<Message> Messages { get; } = [];

    [Reactive] public string? IP { get; set;} = "127.0.0.1";
    [Reactive] public string? Port { get; set; } = "65000";
    [Reactive] public string? Name { get; set; } = "anst";
    [Reactive] public string? Message { get; set;}//FIXME
    
    public ReactiveCommand<Unit, Unit> CommandConnect { get;}
    public ReactiveCommand<Unit, Unit> CommandSend { get;}
    
    public MainWindowViewModel()
    {
        CommandConnect = ReactiveCommand.CreateFromTask(ConnectAsync);
        CommandSend = ReactiveCommand.CreateFromTask(SendAsync);
    }

    private async Task ConnectAsync() //FIXME
    {
        var ip = IPAddress.Parse(IP);
        var port = int.Parse(Port);
        _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        await _server.ConnectAsync(ip, port);
        
        _networkStream = new NetworkStream(_server);
        
        var message = new Message(Name, MessageType.Connect, "null");
        var json = JsonSerializer.Serialize(message);
        var buffer = Encoding.UTF8.GetBytes(json);
        await _networkStream.WriteAsync(buffer);
    }
    
    private async Task SendAsync() //FIXME
    {
        var message = new Message(Name, MessageType.Text, Message);
        var json = JsonSerializer.Serialize(message);
        var buffer = Encoding.UTF8.GetBytes(json);
        await _networkStream.WriteAsync(buffer);
    }
}