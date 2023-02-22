
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;


namespace TimeServer
{


    class Program
    {
        static void Main(string[] args)
        {
            string IPAddress = ConfigurationManager.AppSettings["IPAddress"];
            int PORT = int.Parse(ConfigurationManager.AppSettings["PORT"]);
            Server.CreateServer(IPAddress, PORT);




        }
    }
}