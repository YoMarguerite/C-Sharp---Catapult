using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    class Rope : Element
    {
        public override Boolean checklife()
        {
            if (base.checklife())
            {
                Console.WriteLine("Chief, Rope is Ready !");
            }
            else
            {
                Console.WriteLine("Chief, Rope is break !");
            }

            return base.checklife();
        }

        public override void Action()
        {
            Console.WriteLine("Chief, Rope is Tight !");
        }
    }
}
