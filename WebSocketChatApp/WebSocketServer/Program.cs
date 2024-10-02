using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        WebSocketManager server = new WebSocketManager();
        await server.StartServerAsync();
    }
}
