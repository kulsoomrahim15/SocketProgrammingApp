using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientSide
{
    public static class Client
    {



        public static void InvokeServerForTime(string IPaddress, int port)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(IPaddress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);

                // Send a message to the server
                string message = "What is the current time?";
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                sender.Send(messageBytes);

                // Receive the response
                byte[] buffer = new byte[1024];
                int bytesReceived = sender.Receive(buffer);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                Console.WriteLine("Server's response: " + response);

                // Close the connection
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();


            }

            catch (Exception ex)
            {



                Console.WriteLine("An exception occurred: {0}", ex.Message);
            }
        }
    }
}
