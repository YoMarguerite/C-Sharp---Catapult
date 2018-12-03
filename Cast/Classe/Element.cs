using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Classe
{
    class Element : Ibreakable
    {
        protected String name;
        protected int vie;

        public int Life
        {
            get { return vie;  }
            set { vie = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual void Action() { }


        public Boolean checklife()
        {
            return (vie > 0);
        }
    }
}
