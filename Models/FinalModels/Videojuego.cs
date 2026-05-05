using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Representa un videojuego con su lugar en el catálogo, nombre, género y plataforma.
    /// </summary>
    public class Videojuego : RegistroBase, IComparable<Videojuego>
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
                    throw new VideojuegoException("El lugar en el catálogo debe ser un número positivo.");
                lugarEnElCatalogo = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new VideojuegoException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Genero
        {
            get { return genero; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new VideojuegoException("El género no puede estar vacío.");
                genero = value; 
            }
        }

        public string Plataforma
        {
            get { return plataforma; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new VideojuegoException("La plataforma no puede estar vacía.");
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

        public Videojuego(int lugarEnElCatalogo)
        {
            LugarEnElCatalogo = lugarEnElCatalogo;
        }
        public Videojuego() { }
        /// <summary>
        /// Devuelve un resumen descriptivo del videojuego.
        /// </summary>
        /// <returns>Una cadena con el nombre, género y plataforma del videojuego.</returns>
        public override string Resumen()
        {
            return "Juego: " + Nombre + " | Género: " + Genero + " | Plataforma: " + Plataforma;
        }

        /// <summary>
        /// Compara dos videojuegos por su lugar en el catálogo.
        /// </summary>
        /// <param name="other">El otro videojuego a comparar.</param>
        /// <returns>Un entero que indica el orden relativo.</returns>
        public int CompareTo(Videojuego? other)
        {
            return LugarEnElCatalogo.CompareTo(other.LugarEnElCatalogo);
        }

        public override string ToString()
        {
            return "(" + LugarEnElCatalogo.ToString() + ", " + Nombre + ", " + Genero + ", " + Plataforma + ")";
        }
    }
}
