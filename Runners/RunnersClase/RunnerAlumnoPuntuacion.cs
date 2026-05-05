using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models.ModelsClase;

namespace APS_Eq_TeamAltF4_U3.Runners.RunnersClase
{
    public class RunnerAlumnoPuntuacion
    {
        public RunnerAlumnoPuntuacion()
        {

            Score.Puntuacion = 10;
            Console.WriteLine(Score.Puntuacion.ToString());
            Score.Puntuacion += 15;
            Console.WriteLine(Score.Puntuacion.ToString());

        }

    }
}
