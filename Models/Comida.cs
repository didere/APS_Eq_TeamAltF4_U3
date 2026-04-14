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
            set { lugarEnMenu = value; }
        }

        public string Nombre
        {
             get { return nombre; }
            set { nombre = value; }
        }

        public string PaisOrigen
        {
            get { return paisOrigen; }
            set { paisOrigen = value; }
        }

        public int Costo
        {
            get { return costo; }
            set { costo = value; }
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
