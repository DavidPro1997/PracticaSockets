using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClienteUDPBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            //se crea el cliente UDP y se le asigna un socket
            UdpClient local = new UdpClient("127.0.0.1", 9050);

            //Inicializacion de variables
            int p1 = 45; 
            double p2 = 3.14159; 
            int p3 = -1234567890; 
            bool p4 = false; 
            string p5 = "This is a test.";

            //Convierte los datos especificados en una matriz de bytes.
            byte[] data1 = BitConverter.GetBytes(p1);

            //Envia datos a un socket vinculado 
            local.Send(data1, data1.Length);
            byte[] data2 = BitConverter.GetBytes(p2); 
            local.Send(data2, data2.Length);
            byte[] data3 = BitConverter.GetBytes(p3); 
            local.Send(data3, data3.Length);
            byte[] data4 = BitConverter.GetBytes(p4); 
            local.Send(data4, data4.Length);
            byte[] data5 = Encoding.ASCII.GetBytes(p5); 
            local.Send(data5, data5.Length);
            local.Close();
        }
    }
}
