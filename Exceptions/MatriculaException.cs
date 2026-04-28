using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Exceptions
{
    internal class MatriculaException : Exception
    {
        public MatriculaException(string message) : base(message)
        {
            // Guardar en la base de datos que este error fue triggereado
        }
    }
}
