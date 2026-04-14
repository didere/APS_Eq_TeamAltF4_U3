using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Mascota
    {
        private int id;
        private string nombre;
        private string raza;
        private int edad;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public Mascota(int id, string nombre, string raza, int edad)
        {
            Id = id;
            Nombre = nombre;
            Raza = raza;
            Edad = edad;
        }

        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + Raza + ", " + Edad.ToString() + ")";
        }
    }
}
