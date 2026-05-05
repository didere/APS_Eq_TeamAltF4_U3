using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models.ModelsClase;

namespace APS_Eq_TeamAltF4_U3.Runners.RunnersClase
{
    public class Runner01_ArchivoAlumno
    {
        public Runner01_ArchivoAlumno() 
        {
            Alumno al1 = new Alumno(1, "Emilio Perez");
            Alumno al2 = new Alumno(2, "Juan Sanchez");
            Alumno al3 = new Alumno(3, "Juan Segundo");
            StreamWriter sw = new StreamWriter("alumnos.csv");

            sw.WriteLine(al1.Matricula + "," + al1.Nombre);
            sw.WriteLine(al2.Matricula + "," + al2.Nombre);
            sw.WriteLine(al3.Matricula + "," + al3.Nombre);
            sw.Flush();
            sw.Close();
        } 
    }
}
