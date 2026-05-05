using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática con operaciones de estadística para listas de Mascota.
    /// No puede instanciarse ni heredarse.
    /// </summary>
    public static class EstadisticasMascota
    {
        /// <summary>
        /// Devuelve la edad mínima entre todas las mascotas registradas.
        /// </summary>
        /// <param name="mascotas">Lista de mascotas a evaluar.</param>
        /// <returns>La edad mínima encontrada.</returns>
        public static int EdadMinima(List<Mascota> mascotas)
        {
            int edadMin = mascotas[0].Edad;
            foreach (Mascota m in mascotas)
            {
                edadMin = Math.Min(edadMin, m.Edad);
            }
            return edadMin;
        }
    }
}
