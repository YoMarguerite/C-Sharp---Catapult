using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Package.Exceptions
{
   
    public class FormatLifeException : FormatException
    {
        public FormatLifeException(string valeur) : base("FormatLifeException : La valeur récupérez : " + valeur + " ne correponds pas à la vie d'un élément.") {}
    }
}
