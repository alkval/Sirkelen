using Microsoft.AspNetCore.SignalR.Client;
namespace Sirkelen.Shared.Services;
using Sirkelen.Shared.Models;
using System.Net.Http.Json;
using Sirkelen.Shared.infrastructure.Data;

public class ChatService
{
    private HubConnection _hubConnection;

    public async Task InitializeSignalR()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://your-server-url/chathub")
            .Build();

        await _hubConnection.StartAsync();
    }

    public async Task SendMessage(string user, string message)
    {
        await _hubConnection.InvokeAsync("SendMessage", user, message);
    }

    public void ReceiveMessage(Action<string, string> handleReceivedMessage)
    {
        _hubConnection.On<string, string>("ReceiveMessage", (user, message) => 
        {
            handleReceivedMessage(user, message);
        });
    }
}