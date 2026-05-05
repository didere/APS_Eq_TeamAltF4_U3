using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática con operaciones de estadística para listas de Videojuego.
    /// No puede instanciarse ni heredarse.
    /// </summary>
    public static class EstadisticasVideojuego
    {
        /// <summary>
        /// Devuelve la diferencia absoluta entre el primer y último lugar del catálogo.
        /// </summary>
        /// <param name="videojuegos">Lista de videojuegos a evaluar.</param>
        /// <returns>La diferencia absoluta entre el primer y último lugar.</returns>
        public static int DiferenciaCatalogo(List<Videojuego> videojuegos)
        {
            return Math.Abs(videojuegos[0].LugarEnElCatalogo - videojuegos[videojuegos.Count - 1].LugarEnElCatalogo);
        }
    }
}
