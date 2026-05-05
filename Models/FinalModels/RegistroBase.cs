using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase base abstracta para todos los modelos de registro.
    /// Define el contrato que cada modelo debe implementar.
    /// </summary>
    public abstract class RegistroBase
    {
        /// <summary>
        /// Devuelve un resumen descriptivo del registro.
        /// Cada clase hija debe implementar este método.
        /// </summary>
        /// <returns>Una cadena con el resumen del registro.</returns>
        public abstract string Resumen();
    }
}
