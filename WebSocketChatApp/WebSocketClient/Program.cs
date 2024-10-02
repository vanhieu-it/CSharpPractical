using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        using (ClientWebSocket webSocket = new ClientWebSocket())
        {
            Uri serverUri = new Uri("ws://localhost:8080/ws/");
            await webSocket.ConnectAsync(serverUri, CancellationToken.None);
            Console.WriteLine("Connected to WebSocket server!");

            // Chọn phòng chat
            Console.WriteLine("Enter the chat room you want to join:");
            string room = Console.ReadLine();
            await SendMessageAsync(webSocket, room);

            // Tạo task riêng để nhận tin nhắn từ server
            _ = Task.Run(() => ReceiveMessages(webSocket));

            while (webSocket.State == WebSocketState.Open)
            {
                Console.WriteLine("Enter a message to send to the server (or 'exit' to close):");
                string message = Console.ReadLine();

                if (message == "exit")
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client exiting", CancellationToken.None);
                    break;
                }

                await SendMessageAsync(webSocket, message);
            }
        }
    }

    private static async Task SendMessageAsync(ClientWebSocket webSocket, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }

    private static async Task ReceiveMessages(ClientWebSocket webSocket)
    {
        byte[] buffer = new byte[1024];

        while (webSocket.State == WebSocketState.Open)
        {
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            Console.WriteLine("Received from server: " + message);
        }
    }
}
