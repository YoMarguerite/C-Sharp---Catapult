using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Classe
{
    class Canon : ArmeDeJet
    {
        public override void Tir()
        {
            Console.WriteLine("Mettre le feu au poudre !");
        }

        public override void PrepaTir()
        {
            Console.WriteLine("Charger le boulet");
        }



    }
}
