using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace ServidorUDP
{
    class Program
    {
        //Puerto por donde van a ir los mensajes
        private const int puertoEscucha = 11000;
        static void Main(string[] args)
        {

            bool terminado = false;
            //se crea el cliente udp y se le asigna un puerto
            UdpClient servidor = new UdpClient(puertoEscucha);

            //Representa un extremo de la red como una dirección IP y un número de puerto.
            IPEndPoint sitioRemoto = new IPEndPoint(IPAddress.Any, puertoEscucha);
            
            //variables a usar
            string datosRx; 
            byte[] bufferRx;
            Console.WriteLine("Empezando ….");
            
            //revisa que haya mensajes
            while (!terminado) { Console.WriteLine("Esperando por mensajes ….");
                
                //Recibe datos de un socket vinculado 
                bufferRx = servidor.Receive(ref sitioRemoto); 

                //Avisa que se ha recibido mensajes
                Console.WriteLine("Se recibió un mensaje de " + sitioRemoto);

                //Decodifica un rango de bytes de una matriz de bytes en una cadena.
                datosRx = Encoding.ASCII.GetString(bufferRx, 0, bufferRx.Length); 

                //Imprime el resultado
                Console.WriteLine("El contenido del mensaje es: \n" + datosRx); 
            }
        }
    }
}
