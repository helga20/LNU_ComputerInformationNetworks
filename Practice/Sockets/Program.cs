using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Sockets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress adr = Dns.GetHostEntry("localhost").AddressList[0];
            Socket Listener = new Socket(adr.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 

            IPEndPoint iPEnd = new IPEndPoint(adr, 8086);

            Listener.Bind(iPEnd); 
            Listener.Listen(10); 
            Console.WriteLine("Waiting for connection");
            
            Socket socket = Listener.Accept();  
            byte[] buffer = new byte[1024]; 

          
            socket.Receive(buffer); 
            string data = Encoding.ASCII.GetString(buffer); 
            Console.WriteLine($"Hello {data} !!!"); 


            socket.Close();  
        }

    }
}
