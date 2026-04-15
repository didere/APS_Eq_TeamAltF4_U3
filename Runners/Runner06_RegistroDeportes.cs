using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner06_RegistroDeportes
    {
        public Runner06_RegistroDeportes()
        {
            string ruta = "deportes.csv";
            List<Deporte> deportes = new List<Deporte>();
            if (File.Exists(ruta))
            {
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    int lugarEnELRanking = Convert.ToInt32(datos[0]);
                    string nombre = datos[1];
                    string tipoDeporte = datos[2];
                    int cantidadDeJugadores = Convert.ToInt32(datos[3]);
                    Deporte deporte = new Deporte(lugarEnELRanking, nombre, tipoDeporte, cantidadDeJugadores);
                    deportes.Add(deporte);
                }
            }
            else

            {
                Console.WriteLine("No existen registros previos");
            }
            int deportes_registrados = deportes.Count;
            int opcion = 0;
            do
            {
                Console.WriteLine("Ranking mundial de deportes:");
                Console.WriteLine("1. Registrar deporte");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa el lugar del deporte en el ranking mundial:");
                        int lugarEnELRanking = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre del deporte:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa el tipo de deporte:");
                        string tipoDeporte = Console.ReadLine();
                        Console.WriteLine("Ingresa la cantidad de jugadores que participan en el deporte:");
                        int cantidadDeJugadores = Convert.ToInt32(Console.ReadLine());
                        Deporte deporte = new Deporte(lugarEnELRanking, nombre, tipoDeporte, cantidadDeJugadores);
                        StreamWriter sw = new StreamWriter(ruta, append: true);
                        sw.WriteLine(deporte.LugarEnElRanking + "," + deporte.Nombre + "," + deporte.TipoDeporte + "," + deporte.CantidadDeJugadores);
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
