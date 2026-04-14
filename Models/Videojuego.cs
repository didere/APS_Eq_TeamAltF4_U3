using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Videojuego
    {
        private int id;
        private string nombre;
        private string genero;
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
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public Videojuego(int id, string nombre, string genero)
        {
            Id = id;
            Nombre = nombre;
            Genero = genero;
        }
        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + Genero + ")";
        }
    }
}
