using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models.ModelsClase
{
    public class Triangulo : Poligono
    {

        // manejo de exceopciones
        // comentarios
        // clases abstractas:solo se pueden instanciar con hijos y clases estaticas no pueden tener hijos ni ser instanciadas
        //
        /// <summary>
        ///  Se espera dos parámetros: la base y la altura del triángulo. El área se calcula utilizando la fórmula: (base * altura) / 2.
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override int CalcArea(int[] parametros)
        {
            if (parametros.Length != 2)
            {
                throw new ArgumentException("El triángulo requiere dos parámetros: base y altura.");
            }
            return parametros[0] * parametros[1] / 2;
        }
    }
}
