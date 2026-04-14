using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class Runner02_RegistroAlumnos
    {
        public Runner02_RegistroAlumnos()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Ingresa la acción deseada:");
                Console.WriteLine("1. Registrar alumno");
                Console.WriteLine("0. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresa el nombre del alumno:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa la matrícula del alumno:");
                        long matricula = Convert.ToInt64(Console.ReadLine());
                        Alumno al = new Alumno(matricula, nombre);
                        StreamWriter sw = new StreamWriter("registro.csv");
                        sw.WriteLine(al.Matricula + "," + al.Nombre);
                        sw.Flush();
                        sw.Close();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el Programa");
                        break;
                }
            } while (opcion != 0);
        }
    }
}
