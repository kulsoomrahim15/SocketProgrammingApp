using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace TimeServer
{
    public static class Server
    {
        public static void CreateServer(string IPaddress, int port)

        {
            try
            {
                // Create a TCP/IP socket
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

              
                IPAddress ipAddress = IPAddress.Parse(IPaddress);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                listener.Bind(localEndPoint);
                listener.Listen(10); // Maximum number of connection request it can handle 

                Console.WriteLine("Server started. Waiting for a connection...");

                while (true)
                {
                    
                    Socket handler = listener.Accept();

                    // Receive the client's message
                    byte[] buffer = new byte[1024];
                    int bytesReceived = handler.Receive(buffer);
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                    Console.WriteLine("Received message from client: " + message);

                    // Send the current time as a response

                    handler.Send(GetCurrentTime());

                    // Close the connection
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("An exception occurred: {0}", ex.Message);
            }
        }

        public static byte[] GetCurrentTime()
        {

            {
                string response = DateTime.Now.ToString();
                byte[] responseBytes = Encoding.ASCII.GetBytes(response);

                return responseBytes;

            }
        }
    }
}