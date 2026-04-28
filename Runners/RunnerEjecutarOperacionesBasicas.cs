using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Utilidades;
namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class RunnerEjecutarOperacionesBasicas
    {
        public RunnerEjecutarOperacionesBasicas()
        {
            //int resultadoSuma = OperacionesBasicas.Suma(5, 3);
            int resultadoMultiplicacion = OperacionesBasicas.Multiplicacion(10, 20);

            double indiceReprobacion = OperacionesBasicas.Indice_Reprobacion;
            Console.WriteLine($"El resultado de la multiplicación es: {resultadoMultiplicacion}");
            Console.WriteLine($"El índice de reprobación es: {indiceReprobacion}"); 
        }
    }
}
