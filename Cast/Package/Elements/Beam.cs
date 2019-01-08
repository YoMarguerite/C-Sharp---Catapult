using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    class Beam : Element
    {
        public override Boolean checklife()
        {
            if (base.checklife())
            {
                Console.WriteLine("Chief, Beam is Ready !");
            }
            else
            {
                Console.WriteLine("Chief, Beam is break !");
            }

            return base.checklife();
        }

        public override void Action()
        {
            Console.WriteLine("Chief, Beam correctly stop the Arm !");
        }
    }
}
