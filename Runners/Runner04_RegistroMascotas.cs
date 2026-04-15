using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner04_RegistroMascotas
    {
        public Runner04_RegistroMascotas()
        {
            string ruta = "mascotas.csv";
            List<Mascota> mascotas = new List<Mascota>();
            if (File.Exists(ruta)) 
            {
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    int id = Convert.ToInt32(datos[0]);
                    string nombre = datos[1];
                    string tipoMascota = datos[2];
                    string especie = datos[3];
                    int edad = Convert.ToInt32(datos[4]);
                    Mascota mascota = new Mascota(id, nombre,tipoMascota, especie, edad);
                    mascotas.Add(mascota);
                }
            }
            else

            {
                Console.WriteLine("No existen registros previos");
            }
            int mascotas_registradas = mascotas.Count;
            int opcion = 0;
            do
            {
                Console.WriteLine("Sistema de adopcion de mascotas:");
                Console.WriteLine("1. Registrar mascota");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa el id del animal:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresa el nombre del animal:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa el tipo de mascota:");
                        string tipoMascota = Console.ReadLine();
                        Console.WriteLine("Ingresa la raza del animal:");
                        string raza = Console.ReadLine();
                        Console.WriteLine("Ingresa la edad del animal:");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Mascota mascota = new Mascota(id, nombre, tipoMascota, raza, edad);
                        mascotas.Add(mascota);
                        StreamWriter sw = new StreamWriter(ruta, true);
                        sw.WriteLine(mascota.Id + "," + mascota.Nombre + "," + mascota.TipoMascota + "," + mascota.Raza + "," + mascota.Edad);
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
