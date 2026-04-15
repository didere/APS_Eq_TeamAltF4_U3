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
        private string tipoMascota;
        private string raza;
        private int edad;

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID debe ser un número positivo.");
                id = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length > 60)
                    throw new ArgumentException("El nombre no puede exceder 60 caracteres.");
                nombre = value;
            }
        }

        public string TipoMascota
        {
            get { return tipoMascota; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo de mascota no puede estar vacío.");
                if (value.Length > 60)
                    throw new ArgumentException("El tipo de mascota no puede exceder 60 caracteres.");
                tipoMascota = value;
            }
        }

        public string Raza
        {
            get { return raza; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La raza no puede estar vacía.");
                if (value.Length > 60)
                    throw new ArgumentException("La raza no puede exceder 60 caracteres.");
                raza = value;
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La edad no puede ser negativa.");
                if (value > 100)
                    throw new ArgumentException("La edad ingresada no es válida.");
                edad = value;
            }
        }

        public Mascota(int id, string nombre, string tipoMascota, string raza, int edad)
        {
            Id = id;
            Nombre = nombre;
            TipoMascota = tipoMascota;
            Raza = raza;
            Edad = edad;
        }

        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + TipoMascota + ", " + Raza + ", " + Edad.ToString() + ")";
        }
    }
}
