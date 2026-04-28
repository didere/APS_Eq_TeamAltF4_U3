using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_Eq_TeamAltF4_U3.Models;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class RunnerAreasPoligonos
    {
        public RunnerAreasPoligonos()
        {
            // las clases abstractas no se referencian
            // directamente si no que se hace desde la clase hija
            Poligono poligono;
            poligono = new Triangulo();

            Triangulo triangulo;
            triangulo = new Triangulo();
            double a = triangulo.CalcArea(new int[] { 5, 10 });
            a = poligono.CalcArea(new int[] { 5, 10 });
            Console.WriteLine("El área del triángulo es: " + a);

        }
    }
}
