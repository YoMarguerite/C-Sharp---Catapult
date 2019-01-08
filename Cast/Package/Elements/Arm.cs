using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    class Arm : Element
    {
        public override Boolean checklife()
        {
            if (base.checklife())
            {
                Console.WriteLine("Chief, Arm is Ready !");
            }
            else
            {
                Console.WriteLine("Chief, Arm is break !");
            }

            return base.checklife();
        }

        public override void Action()
        {
            Console.WriteLine("Chief, Arm is launching the Spoon !");
        }
    }
}
