using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.FinalModels
{
    /// <summary>
    /// Clase estática con operaciones de estadística para listas de Deporte.
    /// No puede instanciarse ni heredarse.
    /// </summary>
    public static class EstadisticasDeporte
    {
        /// <summary>
        /// Devuelve la raíz cuadrada del total de jugadores de todos los deportes registrados.
        /// </summary>
        /// <param name="deportes">Lista de deportes a evaluar.</param>
        /// <returns>El promedio de jugadores por deporte, redondeado a 2 decimales.</returns>
        public static double PromedioJugadores(List<Deporte> deportes)
        {
            int totalJugadores = 0;
            foreach (Deporte d in deportes)
            {
                totalJugadores += d.CantidadDeJugadores;
            }
            return Math.Round((double)totalJugadores / deportes.Count, 2);
        }
    }
}
