using System;
using System.Net;
using System.Net.Sockets;

namespace TimeoutUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Representa un extremo de la red como una dirección IP y un número de puerto.
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            //se crea el cliente udp y se le asigna un socket
            UdpClient servidor = new UdpClient(ip);

            //se crea un socket udp 
            Socket socketUdp = servidor.Client;

            //Devuelve el valor del timeout del Socket especificado.
            int to = (int)socketUdp.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout); 
            Console.WriteLine("Timeout por defecto: {0}", to);

            //Devuelve el valor del timeout del Socket especificado alterado.
            socketUdp.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000); 
            to = (int)socketUdp.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout); 

            Console.WriteLine("Timeout modificado: {0}", to); 
            servidor.Close(); 
            Console.ReadLine();
        }
    }
}
