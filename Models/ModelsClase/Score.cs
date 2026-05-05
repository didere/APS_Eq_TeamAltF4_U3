using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.ModelsClase
{
    public class Score
    {
        private static int puntuacion;

        public static int Puntuacion
        {
            get { return puntuacion; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La puntuación no puede ser negativa.");
                puntuacion = value;
            }
        }
    }
}
