using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main(string[] args)
    {
        string ipAddress = "127.0.0.1";
        int port = 8080;

        TcpClient client = new TcpClient(ipAddress, port);
        Console.WriteLine("Connected to server");

        NetworkStream stream = client.GetStream();

        string message = "Hello from the client";
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Sent: {0}", message);

        data = new byte[256];
        int bytes = stream.Read(data, 0, data.Length);
        message = Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", message);

        client.Close();
    }
}
