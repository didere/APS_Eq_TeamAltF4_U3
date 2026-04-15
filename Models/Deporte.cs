using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Deporte
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
                    throw new ArgumentException("El lugar en el ranking debe ser un número positivo.");
                lugarEnElRanking = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre no puede exceder 100 caracteres.");
                nombre = value;
            }
        }

        public string TipoDeporte
        {
            get { return tipoDeporte; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo de deporte no puede estar vacío.");
                if (value.Length > 60)
                    throw new ArgumentException("El tipo de deporte no puede exceder 60 caracteres.");
                tipoDeporte = value;
            }
        }

        public int CantidadDeJugadores
        {
            get { return cantidadDeJugadores; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("La cantidad de jugadores debe ser al menos 1.");
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

        public override string ToString()
        {
            return "(" + LugarEnElRanking.ToString() + ", " + Nombre + ", " + TipoDeporte + ", " + CantidadDeJugadores + ")";
        }
    }
}
