using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    public class Deporte
    {
        private int id;
        private string nombre;
        private string tipoDeporte;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string TipoDeporte
        {
            get { return tipoDeporte; }
            set { tipoDeporte = value; }
        }

        public Deporte(int id, string nombre, string tipoDeporte)
        {
            Id = id;
            Nombre = nombre;
            TipoDeporte = tipoDeporte;
        }

        public override string ToString()
        {
            return "(" + Id.ToString() + ", " + Nombre + ", " + TipoDeporte + ")";
        }
    }
}
