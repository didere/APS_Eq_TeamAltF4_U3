using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class JsonArchivoAlumno
    {
        public JsonArchivoAlumno()
        {

            Alumno al1;
            Alumno al2;
            Alumno al3;

            Random random;
            StreamReader sr;
            StreamWriter sw;

            //De clases statics no se puede generar objetos
            // Jsonserializer serializer;
            // Math math;

            al1 = new Alumno(56, "Gato", 10);
            al2 = new Alumno(57, "Perro", 9);

            al3 = new Alumno(58, "Pato", 8);

            sw = new StreamWriter("Alumnos.json");

            string json = JsonSerializer.Serialize(al1);
            sw.WriteLine(json);

            json = JsonSerializer.Serialize(al2);
            sw.WriteLine(json);

            json = JsonSerializer.Serialize(al3);
            sw.WriteLine(json);
        }
    }
}
