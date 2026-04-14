using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Alumno
    {
        private long matricula;
        private string nombre;

        public long Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Alumno(long matricula, string nombre)
        {
            Matricula = matricula;
            Nombre = nombre;
        }
        public override string ToString()
        {
            return "(" + Matricula.ToString() + ", " + Nombre + ")";
        }
    }
}
