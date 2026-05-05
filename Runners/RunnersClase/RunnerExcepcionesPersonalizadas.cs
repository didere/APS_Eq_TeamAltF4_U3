using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Exceptions;
using APS_Eq_TeamAltF4_U3.Models.ModelsClase;

namespace APS_Eq_TeamAltF4_U3.Runners.RunnersClase
{
    public class RunnerExcepcionesPersonalizadas
    {
        public RunnerExcepcionesPersonalizadas()
        {
            try
            {
                Alumno al = new Alumno();
                long matricula = 1000;
                al.Matricula = matricula;
            
                Console.WriteLine(al);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MatriculaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
