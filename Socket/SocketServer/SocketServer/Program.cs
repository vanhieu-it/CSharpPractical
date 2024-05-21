using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddr, port);

            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Start a new thread to handle the client
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[1024];
            int i;

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine($"Received: {data}");

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
