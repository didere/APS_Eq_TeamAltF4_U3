using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Eq_TeamAltF4_U3.Runners
{
    public class RunnerLeerArchivos
    {
        public RunnerLeerArchivos()
        {

            LeerArchivos.Leer();

            LeerArchivos archivo;
            archivo = new LeerArchivos();
            //archivo.Leer();
            archivo.LeerV2();


        }
    }
}
