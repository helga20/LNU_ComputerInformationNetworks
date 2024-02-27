using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static void Main()
        {
            IPAddress address = Dns.GetHostEntry("localhost").AddressList[0];
            Socket socket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(address, 8086);

            socket.Connect(endPoint);

            Console.WriteLine("Connected");
            Console.WriteLine("Enter your name");

            string name = Console.ReadLine();
            byte[] d = Encoding.ASCII.GetBytes(name);
            socket.Send(d);
            socket.Close();
        }

    }
}
