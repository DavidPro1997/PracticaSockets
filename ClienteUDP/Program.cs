using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClienteUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool terminado = false;

            //Mostramos un mensaje al usuario
            Console.WriteLine("Por favor, introduzca el puerto del servidor: ");

            //Capturamos el dato introducido por el usuario
            int puerto;
            puerto = int.Parse(Console.ReadLine());

            //Mostramos un mensaje al usuario
            Console.WriteLine("Por favor, introduzca la direccion IP del servidor: ");

            //Capturamos el dato introducido por el usuario
            String dir;
            dir = Console.ReadLine();

            //se crea el cliente udp sin puerto
            UdpClient cliente = new UdpClient();

            //Se asigna una direccion IP y la convierte en una instancia de IPAddress .
            IPAddress servidorIP = IPAddress.Parse(dir);

            //Representa un extremo de la red como una dirección IP y un número de puerto.
            IPEndPoint puntoExtremo = new IPEndPoint(servidorIP, puerto);
            
            Console.WriteLine("Ingrese el texto que a transmitir a " + servidorIP); 
            Console.WriteLine("Para finalizar solo tiene que presionar ENTER");
            while (!terminado)
            {
                Console.WriteLine("Ingrese texto y presione ENTER para enviar");
                Console.WriteLine("O solamente presione ENTER para finalizar"); 

                //Se lee la palabra
                string textoParaEnvio = Console.ReadLine(); 

                //Verifica que haya texto
                if (textoParaEnvio.Length == 0) terminado = true; 

                //Se envia al socket con puerto e IP
                else { Console.WriteLine("Se están enviando datos a la dirección IP: " + puntoExtremo.Address + " con puerto: "  + puntoExtremo.Port);
                    
                    //Decodifica un rango de bytes de una matriz de bytes en una cadena.
                    byte[] bufferTx = Encoding.ASCII.GetBytes(textoParaEnvio);

                    //Encia datos a un socket vinculado 
                    cliente.Send(bufferTx, bufferTx.Length, puntoExtremo); 
                }
            }
        }
    }
}
