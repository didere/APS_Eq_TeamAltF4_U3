using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Pasatiempo
    {
        private int id;
        private string nombre;
        private int fans;

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

        public int Fans
        {
            get { return fans; }
            set { fans = value; }
        }

        public Pasatiempo(int id, string nombre, int fans)
        {
            Id = id;
            Nombre = nombre;
            Fans = fans;
        }
        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + Fans + ")";
        }
     }
}
