using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using APS_Eq_TeamAltF4_U3.Models;
namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner03_RegistroComida
    {
        public Runner03_RegistroComida()
        {
            string ruta = "comida.csv";
            List<Comida> comidas = new List<Comida>();
            if (File.Exists(ruta))
            { 
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    int lugarEnMenu = Convert.ToInt32(datos[0]);
                    string nombre = datos[1];
                    string paisOrigen = datos[2];
                    int costo = Convert.ToInt32(datos[3]);
                    Comida comida = new Comida(lugarEnMenu, nombre, paisOrigen, costo);
                    comidas.Add(comida);
                }
            }
            else
            {
                Console.WriteLine("No existen registros previos");
            }
            int comidasEnMenu = comidas.Count;
            int opcion = 0; 
            do
            {
                Console.WriteLine("Bienvenido al menu digital de el restaurante Mr. Worldwide:");
                Console.WriteLine("1. Registrar comida");
                Console.WriteLine("2.- Ver el menu ");
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
                        StreamWriter sw = new StreamWriter(ruta, append: true);
                        sw.WriteLine(comida.LugarEnMenu + "," + comida.Nombre + "," + comida.PaisOrigen + "," + comida.Costo);
                        sw.Flush();
                        sw.Close();
                        break;
                    case 2:
                        foreach (string linea in File.ReadLines(ruta))
                            Console.WriteLine(linea);
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;                    
                }
            } while (opcion != 0);
        }
    }
}
