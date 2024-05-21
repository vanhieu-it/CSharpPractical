using System;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int port = 8080;
                string server = "127.0.0.1";

                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write("Enter the message to send: ");
                    string message = Console.ReadLine();

                    if (string.IsNullOrEmpty(message))
                    {
                        break;
                    }

                    byte[] data = Encoding.ASCII.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Sent: {message}");

                    data = new byte[1024];
                    int bytes = stream.Read(data, 0, data.Length);
                    string responseData = Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine($"Received: {responseData}");
                }

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"ArgumentNullException: {e}");
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e}");
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
