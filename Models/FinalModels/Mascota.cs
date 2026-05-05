using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Representa una mascota con su id, nombre, tipo, raza y edad.
    /// </summary>
    public class Mascota : RegistroBase, IComparable<Mascota>
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
                    throw new MascotaException("El ID debe ser un número positivo.");
                id = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new MascotaException("El nombre no puede estar vacío.");
                if (value.Length > 60)
                    throw new MascotaException("El nombre no puede exceder 60 caracteres.");
                nombre = value;
            }
        }

        public string TipoMascota
        {
            get { return tipoMascota; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new MascotaException("El tipo de mascota no puede estar vacío.");
                if (value.Length > 60)
                    throw new MascotaException("El tipo de mascota no puede exceder 60 caracteres.");
                tipoMascota = value;
            }
        }

        public string Raza
        {
            get { return raza; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new MascotaException("La raza no puede estar vacía.");
                if (value.Length > 60)
                    throw new MascotaException("La raza no puede exceder 60 caracteres.");
                raza = value;
            }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value < 0)
                    throw new MascotaException("La edad no puede ser negativa.");
                if (value > 100)
                    throw new MascotaException("La edad ingresada no es válida.");
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

        public Mascota(int id)
        {
            Id = id;
        }
        public Mascota()
        {
        }
        /// <summary>
        /// Devuelve un resumen descriptivo de la mascota.
        /// </summary>
        /// <returns>Una cadena con el nombre, tipo y edad de la mascota.</returns>
        public override string Resumen()
        {
            return "Mascota: " + Nombre + " | Tipo: " + TipoMascota + " | Edad: " + Edad + " años";
        }

        /// <summary>
        /// Compara dos mascotas por su ID.
        /// </summary>
        /// <param name="other">La otra mascota a comparar.</param>
        /// <returns>Un entero que indica el orden relativo.</returns>
        public int CompareTo(Mascota? other)
        {
            return Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + TipoMascota + ", " + Raza + ", " + Edad.ToString() + ")";
        }
    }
}
