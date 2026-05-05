using APS_Eq_TeamAltF4_U3.Runners.TrabajoFinal;
public class Program
{
    public static void Main(string[] args)
    {
        //new Runner01_ArchivoAlumno();
        //new Runner02_RegistroAlumnos();
        //new Runner03_RegistroComida();
        //new Runner05_RegistroAlumnos();
        //new JsonLecturaAlumnos();
        //new RunnerExcepcionesPersonalizadas();
        //new RunnerAreasPoligonos();
        //Elaborar un programa que permita un registro de comidas
        // Elaborar un programa que permita el registro de mascotas
        //Elaborar un programa que permita el registro de videojuegos
        //elaborar un programa que permita el registro de pasatiempos
        //Elaborar un programa que permita el registro de deportes
        //cada uno debe de guardar 5 cosas       

        // con los statics se pueden hacer una instancia global que se
        // pueda compartir a travez de clases lo que permite ser capaz
        // de usar la misma localidad de memoria para un mismo objeto
        // por lo que se aplicaran y permaneceran los cambios

        int opc;
        bool continuar = true;
        do 
        { 
            Console.WriteLine("Coleccion de programas de registros");
            Console.WriteLine("Opciones");
            Console.WriteLine("1. Registro de Comidas");
            Console.WriteLine("2. Registro de Mascotas");
            Console.WriteLine("3. Registro de Videojuegos");
            Console.WriteLine("4. Registro de Deportes");
            Console.WriteLine("5. Registro de Pasatiempos");
            Console.WriteLine("0. Salir");
            opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    new Runner03_RegistroComida();
                    break;
                case 2:
                    new Runner04_RegistroMascotas();
                    break;
                case 3:
                    new Runner05_RegistroVideojuegos();
                    break;
                case 4:
                    new Runner06_RegistroDeportes();
                    break;
                case 5:
                    new Runner07_RegistroPasatiempo();
                    break;
                case 0:
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor intenta de nuevo.");
                    break;
            }
        }
        while (continuar);
    }
}
