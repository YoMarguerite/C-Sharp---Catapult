using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Beam : Element
    {
        public bool StopTheArm()
        {
            if (checklife())
            {
                Console.WriteLine("Chief, Beam correctly stop the Arm !");
                return true;
            }
            Console.WriteLine("Chief, Beam is break !");
            return false;
        }
    }
}
