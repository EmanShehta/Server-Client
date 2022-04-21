using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Any, 8000);
            Socket server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server_socket.Bind(ipEndpoint);
            server_socket.Listen(100);
            Socket sock_client = server_socket.Accept();
            string Path_file_location = @"E:\Assignment\server\bin\Debug\netcoreapp3.1";
            string Name_file_text = "Testing.txt";
            byte[] Name_file_server = Encoding.ASCII.GetBytes(Name_file_text);
            byte[] Data_in_file = File.ReadAllBytes(Name_file_text);
            byte[] Data_client = new byte[4 + Name_file_server.Length + Data_in_file.Length];
            byte[] length_file_name = BitConverter.GetBytes(Name_file_server.Length);
            length_file_name.CopyTo(Data_client, 0);   //from 0 
            Name_file_server.CopyTo(Data_client, 4);    // from 4
            Data_in_file.CopyTo(Data_client, 4 + Name_file_server.Length); /// from 4 + file  name length
            sock_client.Send(Data_client);
            Console.WriteLine(Path_file_location + Name_file_text);
            Console.WriteLine(Encoding.ASCII.GetString(Data_in_file));
            Console.WriteLine("The File has been sent successfully.");
            Console.WriteLine("Operation Done .");
            Console.WriteLine("Eman shehta abd alaziz");
            Console.WriteLine("Computer science");
            Console.WriteLine("Section 1");
            sock_client.Shutdown(SocketShutdown.Both);
            sock_client.Close();
            Console.ReadLine();
        }
    }
}

