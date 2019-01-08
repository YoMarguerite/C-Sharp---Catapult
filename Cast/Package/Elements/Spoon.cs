using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    class Spoon : Element
    {

        public override Boolean checklife()
        {
            if (base.checklife())
            {
                Console.WriteLine("Chief, Spoon is Ready !");
            }
            else
            {
                Console.WriteLine("Chief, Spoon is break !");
            }

            return base.checklife();
        }

        public override void Action()
        {
            Console.WriteLine("Chief, Rock is Load !");
        }
    }
}
