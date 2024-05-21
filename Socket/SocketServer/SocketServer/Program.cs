using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the port and IP address for the server
            int port = 8080;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // Create a TCP/IP socket
            TcpListener server = new TcpListener(localAddr, port);

            // Start listening for client requests
            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptTcpClientAsync() for an asynchronous version.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                byte[] bytes = new byte[1024];
                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine($"Received: {data}");

                    // Process the data sent by the client.
                    byte[] msg = Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }

                // Shutdown and end connection
                client.Close();
            }
        }
    }
}
