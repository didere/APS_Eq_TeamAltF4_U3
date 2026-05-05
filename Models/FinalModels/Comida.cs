using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Representa un platillo del menú con su lugar, nombre, país de origen y costo.
    /// </summary>
    public class Comida : RegistroBase, IComparable<Comida>
    {
        private int lugarEnMenu;
        private string nombre;
        private string paisOrigen;
        private int costo;

        public int LugarEnMenu
        {
            get { return lugarEnMenu; }
            set
            {
                if (value <= 0)
                    throw new ComidaException("El lugar en menú debe ser un número positivo.");
                lugarEnMenu = value;
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ComidaException("El nombre no puede estar vacío.");
                if (value.Length > 100)
                    throw new ComidaException("El nombre no puede exceder 100 caracteres.");
                nombre = value;
            }
        }

        public string PaisOrigen
        {
            get { return paisOrigen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ComidaException("El país de origen no puede estar vacío.");
                if (value.Length > 60)
                    throw new ComidaException("El país de origen no puede exceder 60 caracteres.");
                paisOrigen = value;
            }
        }

        public int Costo
        {
            get { return costo; }
            set
            {
                if (value < 0)
                    throw new ComidaException("El costo no puede ser negativo.");
                costo = value;
            }
        }

        public Comida(int lugarEnMenu, string nombre, string paisOrigen, int costo)
        {
            LugarEnMenu = lugarEnMenu;
            Nombre = nombre;
            PaisOrigen = paisOrigen;
            Costo = costo;
        }
        public Comida() { }

        public Comida(int lugarEnMenu)
        {
            LugarEnMenu = lugarEnMenu;
        }
        /// <summary>
        /// Devuelve un resumen descriptivo del platillo.
        /// </summary>
        /// <returns>Una cadena con el nombre, país de origen y costo del platillo.</returns>
        public override string Resumen()
        {
            return "Platillo: " + Nombre + " | Origen: " + PaisOrigen + " | Costo: $" + Costo;
        }

        /// <summary>
        /// Compara dos comidas por su lugar en el menú.
        /// </summary>
        /// <param name="other">La otra comida a comparar.</param>
        /// <returns>Un entero que indica el orden relativo.</returns>
        public int CompareTo(Comida? other)
        {
            return LugarEnMenu.CompareTo(other.LugarEnMenu);
        }

        public override string ToString()
        {
            return "(" + lugarEnMenu.ToString() + ", " + Nombre + ", " + PaisOrigen + ", $" + Costo + ")";
        }
    }
}
