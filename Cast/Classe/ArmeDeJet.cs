using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Classe
{
    public abstract class ArmeDeJet
    {
        public void Tirer(int num)
        {
            Console.WriteLine("Tire avec une puissance de "+num);
        }

        public void Tirer(string num)
        {
            Console.WriteLine("Tire avec " + num);
        }

        public abstract void Tir();

        public virtual void PrepaTir()
        {

        }
        public int Life { get; set; }
    }
}
