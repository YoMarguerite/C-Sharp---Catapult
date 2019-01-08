using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    public abstract class ArmeDeJet
    {
        protected Element[] elements;
        //protected double vie;

        public Element[] Elements
        {
            get { return elements; }
        }

        //public double Vie
        //{
        //    get { return vie; }
        //}

        //public void Set

        public abstract void PrepaTir(List<int> vie_elements);

        public abstract double Tir();

        public abstract bool Verif();

    }
}
