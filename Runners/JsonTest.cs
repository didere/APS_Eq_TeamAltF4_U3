using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class JsonTest
    { 
        public JsonTest()
        {
            Alumno alumno = new Alumno(56, "Gato");
            alumno.Calificacion = 10;
            Console.WriteLine(alumno);
            
            Console.WriteLine();
            string alumno_json = JsonSerializer.Serialize(alumno);
            Console.WriteLine(alumno_json);

            Console.WriteLine();
            Alumno alumnoTemp = JsonSerializer.Deserialize<Alumno>(alumno_json);
            Console.WriteLine(alumnoTemp);
        }
    }
}
