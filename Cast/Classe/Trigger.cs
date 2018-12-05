using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Trigger : Element
    {
        public bool Fire()
        {
            if (checklife())
            {
                Console.WriteLine("Chief, Trigger is Fire !");
                return true;
            }
            Console.WriteLine("Chief, Trigger is break !");
            return false;
        }
    }
}
