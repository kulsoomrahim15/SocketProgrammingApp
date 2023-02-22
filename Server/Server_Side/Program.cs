using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main(string[] args)
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8080;

        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();
        Console.WriteLine("Server is listening on {0}:{1}", ipAddress, port);

        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected");

        NetworkStream stream = client.GetStream();

        byte[] data = new byte[256];
        int bytes = stream.Read(data, 0, data.Length);
        string message = Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", message);

        message = "Hello from the server";
        data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Console.WriteLine("Sent: {0}", message);

        client.Close();
        listener.Stop();
    }
}
