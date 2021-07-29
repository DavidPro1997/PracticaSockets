using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServidorUDPBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            //Representa un extremo de la red como una dirección IP y un número de puerto.
            IPEndPoint miIp = new IPEndPoint(IPAddress.Any, 9050);

            //se crea el cliente UDP y se le asigna un socket
            UdpClient local = new UdpClient(miIp);

            Console.WriteLine("Esperando datos...");

            //Representa un extremo de la red como una dirección IP y un número de puerto.
            IPEndPoint remoto = new IPEndPoint(IPAddress.Any, 0);

            //Recibe datos de un socket vinculado
            //Tranforma de binario a diferentes tipos de dato.
            //Imprime en consola el dato
            byte[] data1 = local.Receive(ref remoto);
            int p1 = BitConverter.ToInt32(data1, 0); 
            Console.WriteLine("1er dato = {0}", p1);
            byte[] data2 = local.Receive(ref remoto); 
            double p2 = BitConverter.ToDouble(data2, 0); 
            Console.WriteLine("2do dato = {0}", p2);
            byte[] data3 = local.Receive(ref remoto); 
            int p3 = BitConverter.ToInt32(data3, 0);
            Console.WriteLine("3er dato = {0}", p3);
            byte[] data4 = local.Receive(ref remoto); 
            bool p4 = BitConverter.ToBoolean(data4, 0); 
            Console.WriteLine("4to dato = {0}", p4.ToString());
            byte[] data5 = local.Receive(ref remoto); 
            string p5 = Encoding.ASCII.GetString(data5); 
            Console.WriteLine("5to dato = {0}", p5);
            local.Close();
        }
    }
}
