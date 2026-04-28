using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class RunnerAlumnoPuntuacion
    {
        public RunnerAlumnoPuntuacion()
        {
            Score.Puntuacion = 10;

            Console.WriteLine(Score.Puntuacion.ToString());
            Score.Puntuacion = 20;
            Console.WriteLine(Score.Puntuacion.ToString());
        }
    }
}
