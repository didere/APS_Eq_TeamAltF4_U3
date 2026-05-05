using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Utilidades;
namespace APS_Eq_TeamAltF4_U3.Runners.RunnersClase
{
    public class RunnerEjecutarOperacionesBasicas
    {
        public RunnerEjecutarOperacionesBasicas()
        {
            //int resultadoSuma = OperacionesBasicas.Suma(5, 3);
            int resultado = OperacionesBasicas.Multiplicacion(2, 4);

            double indiceR = OperacionesBasicas.INDICE_REPROBACION;

            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}
