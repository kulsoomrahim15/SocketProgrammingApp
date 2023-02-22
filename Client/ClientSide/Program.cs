using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using System.Timers;

namespace ClientSide
{
    class Program
    {
        static void Main()
        {
            string IPAddress = ConfigurationManager.AppSettings["IPAddress"];
            int PORT = int.Parse(ConfigurationManager.AppSettings["PORT"]);

            // Client.InvokeServerForTime(IPAddress, PORT);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            // Set the callback function to be executed every 1 second
            timer.Elapsed += (sender, e) => Client.InvokeServerForTime(IPAddress, PORT);
            timer.Start();
            Console.ReadLine();


        }
    }
}