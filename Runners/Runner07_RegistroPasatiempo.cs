using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner07_RegistroPasatiempo
    {
        public Runner07_RegistroPasatiempo()
        {
            string ruta = "pasatiempos.csv";
            List<Pasatiempo> pasatiempos = new List<Pasatiempo>();
            if (File.Exists(ruta))
            {
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    string nombre = datos[0];
                    string frecuencia = datos[1];
                    int horasDedicadas = Convert.ToInt32(datos[2]);
                    Pasatiempo pasatiempo = new Pasatiempo(nombre, frecuencia, horasDedicadas);
                }
            }
            else

            {
                Console.WriteLine("No existen registros previos");
            }
            int pasatiempos_registrados = pasatiempos.Count;
            int opcion = 0;
            do
            {
                Console.WriteLine("Sistema de registro de pasatiempos:");
                Console.WriteLine("1. Registrar pasatiempo");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa el nombre del pasatiempo:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa la frecuencia del pasatiempo:");
                        string frecuencia = Console.ReadLine();
                        Console.WriteLine("Ingresa las horas dedicadas al pasatiempo:");
                        int horasDedicadas = Convert.ToInt32(Console.ReadLine());
                        Pasatiempo pasatiempo = new Pasatiempo(nombre, frecuencia, horasDedicadas);
                        pasatiempos.Add(pasatiempo);                                               
                        StreamWriter sw = new StreamWriter(ruta, true);
                        sw.WriteLine(pasatiempo.Nombre + "," + pasatiempo.Frecuencia + "," + pasatiempo.HorasDedicadas);
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
