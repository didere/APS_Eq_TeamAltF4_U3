using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// clase que no tiene constructores, solo tiene métodos estáticos, por lo que no se puede instanciar
namespace APS_Eq_TeamAltF4_U3.Utilidades
{
    public static class OperacionesBasicas
    {

        public const double Indice_Reprobacion = 0.001;

        public static int Suma(int a, int b)
        {
            return a + b;
        }
        public static int Multiplicacion(int a, int b)
        {
            return a * b;
        }
    }
}
