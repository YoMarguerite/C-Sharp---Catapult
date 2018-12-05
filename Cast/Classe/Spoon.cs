using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    class Spoon : Element
    {
        private int rock;

        public bool LoadTheRock(int rock)
        {
            if (checklife())
            {
                Console.WriteLine("Chief, Spoon is ready !");
                this.rock = rock;
                return true;
            }
            Console.WriteLine("Chief, Spoon is break !");
            return false;
        }

        public int Rock
        {
            get { return rock; }
        }
    }
}
