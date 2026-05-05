using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Representa un pasatiempo con su nombre, frecuencia y horas dedicadas.
    /// </summary>
    public class Pasatiempo : RegistroBase, IComparable<Pasatiempo>
    {
        private string nombre;
        private string frecuencia;
        private int horasDedicadas;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new PasatiempoException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new PasatiempoException("El nombre no puede exceder 100 caracteres.");
                nombre = value;
            }
        }

        public string Frecuencia
        {
            get { return frecuencia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new PasatiempoException("La frecuencia no puede estar vacía.");
                if (value.Length > 60)
                    throw new PasatiempoException("La frecuencia no puede exceder 60 caracteres.");
                frecuencia = value;
            }
        }

        public int HorasDedicadas
        {
            get { return horasDedicadas; }
            set
            {
                if (value < 0)
                    throw new PasatiempoException("Las horas dedicadas no pueden ser negativas.");
                if (value > 168)
                    throw new PasatiempoException("Las horas dedicadas no pueden superar las 168 horas semanales.");
                horasDedicadas = value;
            }
        }

        public Pasatiempo(string nombre, string frecuencia, int horasDedicadas)
        {
            Nombre = nombre;
            Frecuencia = frecuencia;
            HorasDedicadas = horasDedicadas;
        }

        public Pasatiempo() { }

        /// <summary>
        /// Devuelve un resumen descriptivo del pasatiempo.
        /// </summary>
        /// <returns>Una cadena con el nombre, frecuencia y horas dedicadas.</returns>
        public override string Resumen()
        {
            return "Pasatiempo: " + Nombre + " | Frecuencia: " + Frecuencia + " | Horas: " + HorasDedicadas;
        }

        /// <summary>
        /// Compara dos pasatiempos por sus horas dedicadas.
        /// </summary>
        /// <param name="other">El otro pasatiempo a comparar.</param>
        /// <returns>Un entero que indica el orden relativo.</returns>
        public int CompareTo(Pasatiempo? other)
        {
            return HorasDedicadas.CompareTo(other.HorasDedicadas);
        }

        public override string ToString()
        {
            return "(" + Nombre + ", " + Frecuencia + ", " + HorasDedicadas + ")";
        }
    }
}
