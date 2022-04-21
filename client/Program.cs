using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress host_id = IPAddress.Parse("127.0.0.1");  // Socket type== protocoltype  --- tcp   udp
            IPEndPoint Endpointhost = new IPEndPoint(host_id, 8000);
            Socket SOCK = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            SOCK.Connect(Endpointhost);
            byte[] DataforClient = new byte[1024 * 5000];
            string Path_receivied = "E:/Assignment/server/bin/Debug/netcoreapp3.1";
            int receivedBytesLen = SOCK.Receive(DataforClient);
            int Length_file_name = BitConverter.ToInt32(DataforClient, 0);
            string name_file = Encoding.ASCII.GetString(DataforClient, 4, Length_file_name);
            string the_content = Encoding.ASCII.GetString(DataforClient, 4 + Length_file_name, 10000);
            Console.WriteLine(name_file);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("The File has been received successfully.");
            Console.WriteLine("--------------------------------------------------ConTentFile-----------------------------------------------------------");
            Console.WriteLine(the_content);
            SOCK.Close();
            Console.ReadLine();
        }
    }
}
