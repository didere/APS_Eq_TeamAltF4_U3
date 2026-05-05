using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática que mantiene un contador global de registros.
    /// Se comparte entre todos los programas de registro.
    /// </summary>
    public class Contador
    {
        private static int totalRegistros;

        public static int TotalRegistros
        {
            get { return totalRegistros; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El total de registros no puede ser negativo.");
                totalRegistros = value;
            }
        }
    }
}
