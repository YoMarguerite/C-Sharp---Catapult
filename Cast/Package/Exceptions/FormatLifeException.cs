using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Package.Exceptions
{
   
    class FormatLifeException : FormatException
    {
        FormatLifeException(string valeur) : base("La valeur récupérez : " + valeur + " n'est pas correpond à la vie d'un élément.") {}
    }
}
