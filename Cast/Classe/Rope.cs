using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Rope :Element
    {
        private int tension;

        public bool LowerTheSpoon()
        {
            if (checklife())
            {
                Console.WriteLine("Chief, Spoon is Lower !");
                TenseTheRope();
                return true;
            }
            Console.WriteLine("Chief, Rope is break !");
            return false;
        }

        private void TenseTheRope()
        {
            Random randobj = new Random();
            tension = randobj.Next(3,10);
        }

        public int Tension
        {
            get { return tension; }
        }
    }
}
