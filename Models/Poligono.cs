using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Models
{
    // para ahrehar la documentacion se usan tres diagonales
    /// <summary>
    /// Esta clase sirve para calcular el perimetro y el area de un poligono
    /// </summary>

    public abstract class Poligono
    {
        private string nombre;

        public Poligono()
        {
        }
        /// <summary>
        /// Calcula el perímetro de un polígono regular.
        /// </summary>
        /// <param name="lados">Número de lados del polígono.</param>
        /// <param name="longitudLado">Longitud de cada lado del polígono.</param>
        /// <returns>El perímetro del polígono.</returns>
        public int CalcPerimetro(int lados, int longitudLado)
        {
            return lados * longitudLado;
        }

        public abstract int CalcArea(int[] parametros);
    
    }
}
