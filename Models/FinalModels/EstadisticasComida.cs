using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática con operaciones de estadística para listas de Comida.
    /// No puede instanciarse ni heredarse.
    /// </summary>
    public static class EstadisticasComida
    {
        /// <summary>
        /// Devuelve el costo más alto entre todas las comidas registradas.
        /// </summary>
        /// <param name="comidas">Lista de comidas a evaluar.</param>
        /// <returns>El costo máximo encontrado.</returns>
        public static int CostoMaximo(List<Comida> comidas)
        {
            int costoMax = comidas[0].Costo;
            foreach (Comida c in comidas)
            {
                costoMax = Math.Max(costoMax, c.Costo);
            }
            return costoMax;
        }
    }
}
