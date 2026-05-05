using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática con operaciones de estadística para listas de Pasatiempo.
    /// No puede instanciarse ni heredarse.
    /// </summary>
    public static class EstadisticasPasatiempo
    {
        /// <summary>
        /// Devuelve la cantidad de horas dedicadas entre todos los pasatiempos registrados.
        /// </summary>
        /// <param name="pasatiempos">Lista de pasatiempos a evaluar.</param>
        /// <returns>La suma de horas dedicadas entre todos los pasatiempos.</returns>
        public static int Horas(List<Pasatiempo> pasatiempos)
        {
            int totalHoras = 0;
            foreach (Pasatiempo p in pasatiempos)
            {
                totalHoras += p.HorasDedicadas;
            }
            return totalHoras;
        }
    }
}
