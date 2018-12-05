using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Arm : Element
    {
        public bool Move()
        {
            if (checklife())
            {
                return true;
            }
            return false;
        }

        public double LaunchTheSpoon(int weight, int tension)
        {
            if (Move())
            {
                Console.WriteLine("Chief, Arm is launching the Spoon !");
                return (1 / 2) * weight * Math.Pow(tension, 2);
            }
            Console.WriteLine("Chief, Arm is break !");
            return 0;
        }
    }
}
