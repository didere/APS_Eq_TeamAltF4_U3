using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Videojuego
    {
        private int lugarEnElCatalogo;
        private string nombre;
        private string genero;
        private string plataforma;

        public int LugarEnElCatalogo
        {
            get { return lugarEnElCatalogo; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El lugar en el catálogo debe ser un número positivo.");
                lugarEnElCatalogo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Genero
        {
            get { return genero; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El género no puede estar vacío.");
            }
        }

        public string Plataforma
        {
            get { return plataforma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La plataforma no puede estar vacía.");
                plataforma = value;
            }
        }

        public Videojuego(int lugarEnElCatalogo, string nombre, string genero, string plataforma)
        {
            LugarEnElCatalogo = lugarEnElCatalogo;
            Nombre = nombre;
            Genero = genero;
            Plataforma = plataforma;
        }

        public override string ToString()
        {
            return "(" + LugarEnElCatalogo.ToString() + ", " + Nombre + ", " + Genero + ", " + Plataforma + ")";
        }
    }
}
