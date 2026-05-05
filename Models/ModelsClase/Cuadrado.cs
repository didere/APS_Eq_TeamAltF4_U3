using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.ModelsClase
{
    internal class Cuadrado : Poligono
    {
        public override int CalcArea(int[] parametros)
        {
            if (parametros.Length != 1)
            {
                throw new ArgumentException("El cuadrado solo requiere un parámetro: la longitud del lado.");
            }
            return parametros[0] * parametros[0];
        }
    }
}
