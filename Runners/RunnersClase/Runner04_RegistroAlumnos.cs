
using System.Linq;
using APS_Eq_TeamAltF4_U3.Models.ModelsClase;
using Microsoft.Win32;

namespace APS_Eq_TeamAltF4_U3.Runners.RunnersClase
{
    public class Runner04_RegistroAlumnos
    {
        public Runner04_RegistroAlumnos()
        {
            string ruta = "alumnos.csv";
            List<Alumno> alumnos = new List<Alumno>();
            //Cargar el registro 
            if (File.Exists(ruta)) //si existe
            {
                //cargamos el archivo
                foreach (string linea in File.ReadLines(ruta))
                {
                    string[] datos = linea.Split(',');
                    long matricula = Convert.ToInt64(datos[0]);
                    string nombre = datos[1];
                    Alumno al = new Alumno(matricula, nombre);
                    alumnos.Add(al);
                }
            }
            else

            {
                Console.WriteLine("No existen registros previos");
            }
            /*
            foreach (Alumno alumno in alumnos)
            {
                Console.WriteLine(alumnos);
            }
            */
            int alumnos_registrados = alumnos.Count;
            int opcion = 0;
            do
            {
                Console.WriteLine("Ingresa la acción deseada:");
                Console.WriteLine("1. Registrar alumno");
                Console.WriteLine("2. Visualizar registros");
                Console.WriteLine("3. Eliminar alumno");
                Console.WriteLine("4. Guardar cambios");
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
                        alumnos.Add(al);
                        break;
                    case 2:
                        foreach (string linea in File.ReadLines(ruta))
                        {
                            Console.WriteLine(linea);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ingresa la matrícula del alumno a eliminar:");
                        matricula = Convert.ToInt64(Console.ReadLine());
                        Alumno temporal = new Alumno(matricula);
                        bool resultado = alumnos.Contains(new Alumno(matricula));
                        Console.WriteLine(resultado);
                        if (resultado)
                        {
                            alumnos.Remove(temporal);
                        }
                        break;
                    case 4:
                        StreamWriter sw = new StreamWriter(ruta);
                        foreach (Alumno alumno in alumnos)
                        {
                            sw.WriteLine(alumno.Matricula + "," + alumno.Nombre);
                        }
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
