using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Representa un deporte con su lugar en el ranking, nombre, tipo y cantidad de jugadores.
    /// </summary>
    public class Deporte : RegistroBase, IComparable<Deporte>
    {
        private int lugarEnElRanking;
        private string nombre;
        private string tipoDeporte;
        private int cantidadDeJugadores;

        public int LugarEnElRanking
        {
            get { return lugarEnElRanking; }
            set
            {
                if (value <= 0)
                    throw new DeporteException("El lugar en el ranking debe ser un número positivo.");
                lugarEnElRanking = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DeporteException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new DeporteException("El nombre no puede exceder 100 caracteres.");
                nombre = value;
            }
        }

        public string TipoDeporte
        {
            get { return tipoDeporte; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DeporteException("El tipo de deporte no puede estar vacío.");
                if (value.Length > 60)
                    throw new DeporteException("El tipo de deporte no puede exceder 60 caracteres.");
                tipoDeporte = value;
            }
        }

        public int CantidadDeJugadores
        {
            get { return cantidadDeJugadores; }
            set
            {
                if (value < 1)
                    throw new DeporteException("La cantidad de jugadores debe ser al menos 1.");
                cantidadDeJugadores = value;
            }
        }

        public Deporte(int lugarEnElRanking, string nombre, string tipoDeporte, int cantidadDeJugadores)
        {
            LugarEnElRanking = lugarEnElRanking;
            Nombre = nombre;
            TipoDeporte = tipoDeporte;
            CantidadDeJugadores = cantidadDeJugadores;
        }

        public Deporte(int lugarEnElRanking)
        {
            LugarEnElRanking = lugarEnElRanking;
        }

        public Deporte()
        {
        }
        /// <summary>
        /// Devuelve un resumen descriptivo del deporte.
        /// </summary>
        /// <returns>Una cadena con el nombre, tipo y cantidad de jugadores del deporte.</returns>
        public override string Resumen()
        {
            return "Deporte: " + Nombre + " | Tipo: " + TipoDeporte + " | Jugadores: " + CantidadDeJugadores;
        }

        /// <summary>
        /// Compara dos deportes por su lugar en el ranking.
        /// </summary>
        /// <param name="other">El otro deporte a comparar.</param>
        /// <returns>Un entero que indica el orden relativo.</returns>
        public int CompareTo(Deporte? other)
        {
            return LugarEnElRanking.CompareTo(other.LugarEnElRanking);
        }

        public override string ToString()
        {
            return "(" + LugarEnElRanking.ToString() + ", " + Nombre + ", " + TipoDeporte + ", " + CantidadDeJugadores + ")";
        }
    }
}
