using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner03_RegistroComida
    {
        public Runner03_RegistroComida()
        {
            int opcion = 0; 
            do
            {
                Console.WriteLine("Que quieres hacer:");
                Console.WriteLine("1. Registrar comida");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa su lugar en el menu");
                        int lugarEnMenu = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre de la comida");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa el pais de origen de la comida");
                        string paisOrigen = Console.ReadLine();
                        Console.WriteLine("Ingresa el costo de la comida");
                        int costo = Convert.ToInt32(Console.ReadLine());
                        Comida comida = new Comida(lugarEnMenu, nombre, paisOrigen, costo);
                        StreamWriter sw = new StreamWriter("comida.csv");
                        sw.WriteLine(comida.LugarEnMenu + "," + comida.Nombre + "," + comida.PaisOrigen + "," + comida.Costo);
                        sw.Flush();
                        sw.Close();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;                    
                }
            } while (opcion != 0);
        }
    }
}
