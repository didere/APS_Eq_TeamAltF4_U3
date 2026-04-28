using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using APS_Eq_TeamAltF4_U3.Models;
using System.IO;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class JsonLecturaAlumnos
    {
        public JsonLecturaAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            alumnos = new List<Alumno>();
            Alumno temporal;
            foreach (string linea in File.ReadLines("Alumnos.json"))
            {
                temporal = JsonSerializer.Deserialize<Alumno>(linea);
                alumnos.Add(temporal);
            }
            foreach (Alumno alumno in alumnos)
            {
                Console.WriteLine(alumno);
            }
        }
    }
}
