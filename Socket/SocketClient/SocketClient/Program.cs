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
                // Define the port and IP address for the client
                int port = 8080;
                string server = "127.0.0.1";

                // Create a TCP/IP socket
                TcpClient client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a byte array.
                Console.Write("Enter the message to send: ");
                string message = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Sent: {message}");

                // Buffer to store the response bytes.
                data = new byte[1024];

                // String to store the response ASCII representation.
                string responseData = string.Empty;

                // Read the first batch of the TcpServer response bytes.
                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine($"Received: {responseData}");

                // Close everything.
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
