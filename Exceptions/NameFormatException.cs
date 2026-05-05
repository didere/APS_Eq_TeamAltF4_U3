using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APS_Eq_TeamAltF4_U3.Exceptions
{
    public class NameFormatException : Exception
    {
        public NameFormatException(string message) : base(message)
        {
            
        }
    }
}