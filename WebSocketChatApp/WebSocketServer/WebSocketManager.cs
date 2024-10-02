using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class WebSocketManager
{
    private ConcurrentDictionary<string, List<WebSocket>> chatRooms = new ConcurrentDictionary<string, List<WebSocket>>();

    public async Task StartServerAsync()
    {
        HttpListener httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://localhost:8080/ws/");
        httpListener.Start();
        Console.WriteLine("WebSocket Server started at ws://localhost:8080/ws/");

        while (true)
        {
            HttpListenerContext context = await httpListener.GetContextAsync();

            if (context.Request.IsWebSocketRequest)
            {
                HttpListenerWebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                WebSocket webSocket = webSocketContext.WebSocket;

                // Xử lý client trong task riêng
                _ = Task.Run(() => HandleClientAsync(webSocket));
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Close();
            }
        }
    }

    private async Task HandleClientAsync(WebSocket webSocket)
    {
        byte[] buffer = new byte[1024];

        // Bước 1: Yêu cầu client chọn phòng chat
        await SendMessageAsync(webSocket, "Please choose a chat room:");
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        string room = Encoding.UTF8.GetString(buffer, 0, result.Count);

        if (!chatRooms.ContainsKey(room))
        {
            chatRooms[room] = new List<WebSocket>();
        }
        chatRooms[room].Add(webSocket);
        Console.WriteLine($"Client joined room: {room}");
        await SendMessageAsync(webSocket, $"You have joined room: {room}");

        // Bước 2: Nhận và phát sóng tin nhắn trong phòng chat
        while (webSocket.State == WebSocketState.Open)
        {
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Message from {room}: {message}");

                // Phát sóng tin nhắn tới tất cả các client trong cùng phòng
                await BroadcastMessageToRoomAsync(room, message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                chatRooms[room].Remove(webSocket);
                Console.WriteLine($"Client left room: {room}");
            }
        }
    }

    private async Task BroadcastMessageToRoomAsync(string room, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        foreach (var client in chatRooms[room])
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

    private async Task SendMessageAsync(WebSocket webSocket, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }
}
