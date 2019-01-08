using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    class Trigger : Element
    {
        public override Boolean checklife()
        {
            if (base.checklife())
            {
                Console.WriteLine("Chief, Trigger is Ready !");
            }
            else
            {
                Console.WriteLine("Chief, Trigger is break !");
            }

            return base.checklife();
        }

        public override void Action()
        {
            Console.WriteLine("Chief, Trigger is Fire !");
        }
    }
}
