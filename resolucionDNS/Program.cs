// *************************************************************************************************************
// Practica 02
// Integrantes:
//      Luis Eduardo Oña
//      David Proaño
// Fecha de realización: 17/06/2021
// Fecha de entrega: 24/06/2021
// *************************************************************************************************************
// Resultados Ejercicio 1: "Resolución de nombres"
//  * Para la primera ejecucion nos dio el nombre del equipo local y la direccion ip del dominio "www.epn.edu.ec"
//  * El nombre y la direccion ip conciden exactamente con los obtenidos mediante los comandos de Windows.
//  * Se logra codificar de tal forma que se resuelva el nombre y tambien una direccion IP
// *************************************************************************************************************
// Resultados Ejercicio 2: "Uso de UDP"
//  * Se logro crear servidor y clientes UDP donde mediante un socket se logro enviar mensajes 
//  * Si se ingresa mal el puerto o la direccion IP del servidor, los mensajes no llegan del cliente a servidor
// *************************************************************************************************************
// Resultados Ejercicio 3:
//  * Se puedo crear servidor y clientes UDP donde mediante un socket se logro enviar mensajes en forma binaria 
//  * El puerto estaba mal escrito, asi que en principio, los mensajes no llegan del cliente al servidor.
//  * Se logro identificar el error y corregirlo para que funcione el programa.
// *************************************************************************************************************
// Resultados Ejercicio 4:
//  * Logramos como presentar la información del timeout del Socket.
//  * Modificamos el valor del timeout de 0 a 3000. 
// *************************************************************************************************************
// Resultados Ejercicio 5:
// *************************************************************************************************************
// Resultados Ejercicio 6:
// *************************************************************************************************************
// Resultados Ejercicio 7:
// *************************************************************************************************************
// Conclusiones:
//  * Se reconocio las diferentes sentencias de C# para la correcta creación y manipulación de Sockets con UDP,
//    lo cual ayudara a comprender, como cada mensaje viaja mediante UDP por un socket especifico dentro
//    del sistema operativo.

//  * Se evidencio que en UDP no existe handshaking, ya que, los paquetes en ciertas ocaciones se perdian por 
//    una mala congifuracion de los sockets.
//   
//  * Logramos usar una clase en Visual, llamada Dns que contiene métodos para realizar la resolución de nombres,
//    con la ayuda del método GetHostAddresses y GetHostName permite conocer el direcciones IP y nombres
//    respectivamente.
//   
//   
// *************************************************************************************************************
// Recomendaciones:
//  * Se recomienda comentar cada linea de código, ya que, se vuelve mas sencillo de entender cada que queramos
//    ejecutar nuevamente.

//  * Se recomienda revisar el código, debido a que hay ciertos fallos que impiden la ejecucion del programa.

// *************************************************************************************************************



using System;
using System.Net;

namespace resolucionDNS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtiene el nombre del equipo
            Console.WriteLine("Bienvenido! Estas trabajando en: "+Dns.GetHostName());

            //Mostramos un mensaje al usuario
            Console.WriteLine("Por favor, introduzca un nombre a resolver:");

            //Capturamos el dato introducido por el usuario
            String dominio;
            dominio = Console.ReadLine();

            //Mostramos un mensaje al usuario
            Console.WriteLine("La direccion IP asociada al nombre es:");

            //resuelve el nombre de un dominio
            IPAddress[] direccionesIP = Dns.GetHostAddresses(dominio); 

            //Imprime la direccion ip
            foreach (IPAddress ip in direccionesIP) Console.WriteLine(ip.ToString());


            //Mostramos un mensaje al usuario
            Console.WriteLine("Por favor, introduzca una direccion IP a resolver:");

            //Capturamos el dato introducido por el usuario
            String ips;
            ips = Console.ReadLine();

            //Mostramos un mensaje al usuario
            Console.WriteLine("El nombre asociado a la direccion IP es:");

            //Obtiene el nombre 
            IPHostEntry host = Dns.GetHostEntry(ips);

            //Se imprime el nombre
            Console.WriteLine(host.HostName);

          
        }
    }
}
