using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Comida
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
                    throw new ArgumentException("El lugar en menú debe ser un número positivo.");
                lugarEnMenu = value;
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

        public string PaisOrigen
        {
            get { return paisOrigen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El país de origen no puede estar vacío.");
                if (value.Length > 60)
                    throw new ArgumentException("El país de origen no puede exceder 60 caracteres.");
                paisOrigen = value;
            }
        }

        public int Costo
        {
            get { return costo; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El costo no puede ser negativo.");
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

        public override string ToString()
        {
            return "(" + lugarEnMenu.ToString() + ", " + Nombre + ", " + PaisOrigen + ", $" + Costo + ")";
        }
    }
}
