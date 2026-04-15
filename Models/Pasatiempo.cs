using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Pasatiempo
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
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new ArgumentException("El nombre no puede exceder 100 caracteres.");
                nombre = value;
            }
        }

        public string Frecuencia
        {
            get { return frecuencia; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La frecuencia no puede estar vacía.");
                if (value.Length > 60)
                    throw new ArgumentException("La frecuencia no puede exceder 60 caracteres.");
                frecuencia = value;
            }
        }

        public int HorasDedicadas
        {
            get { return horasDedicadas; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Las horas dedicadas no pueden ser negativas.");
                if (value > 168)
                    throw new ArgumentException("Las horas dedicadas no pueden superar las 168 horas semanales.");
                horasDedicadas = value;
            }
        }

        public Pasatiempo(string nombre, string frecuencia, int horasDedicadas)
        {
            Nombre = nombre;
            Frecuencia = frecuencia;
            HorasDedicadas = horasDedicadas;
        }

        public override string ToString()
        {
            return "(" + Nombre + ", " + Frecuencia + ", " + HorasDedicadas + ")";
        }
    }
}
