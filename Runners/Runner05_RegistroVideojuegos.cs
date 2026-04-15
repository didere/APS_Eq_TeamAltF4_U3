using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner05_RegistroVideojuegos
    {
        public Runner05_RegistroVideojuegos()
        {
            string ruta = "videojuegos.csv";
            List<Videojuego> videojuegos = new List<Videojuego>();
            //Cargar el registro 
            if (File.Exists(ruta))
            {
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    int lugarEnElCatalogo = Convert.ToInt32(datos[0]);
                    string nombre = datos[1];
                    string genero = datos[2];
                    string plataforma = datos[3];
                    Videojuego videojuego = new Videojuego(lugarEnElCatalogo, nombre, genero, plataforma);
                    videojuegos.Add(videojuego);
                }
            }
            else

            {
                Console.WriteLine("No existen registros previos");
            }

            int videojuegos_registrados = videojuegos.Count;
            int opcion = 0;
            do
            {
                Console.WriteLine("RetroArch lugar en donde puedes emular juegos antiguos desde tu computadora:");
                Console.WriteLine("1. Registrar videojuego");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa el lugar del videojuego en el catalogo:");
                        int lugarEnElCatalogo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre del videojuego:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa el genero del videojuego:");
                        string genero = Console.ReadLine();
                        Console.WriteLine("Ingresa la plataforma del videojuego:");
                        string plataforma = Console.ReadLine();
                        Videojuego videojuego = new Videojuego(lugarEnElCatalogo, nombre, genero, plataforma);
                        StreamWriter sw = new StreamWriter(ruta, append: true);
                        sw.WriteLine(videojuego.LugarEnElCatalogo + "," + videojuego.Nombre + "," + videojuego.Genero + "," + videojuego.Plataforma);
                        sw.Flush();
                        sw.Close();
                        break;
                    case 2:
                        foreach (string linea in File.ReadLines(ruta))
                        {
                            Console.WriteLine(linea);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el Programa");
                        break;
                }
            } while (opcion != 0);
        }
    }
}
