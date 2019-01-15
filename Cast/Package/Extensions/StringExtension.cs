using Cast.Package.Exceptions;
using System;

//Classe StringExtension

namespace Cast.Package.Extensions
{
    //StringExtension est une classe statique
    public static class StringExtension
    {
        //Méthode statique ToLife, qui prends en paramètre une string et return un int
        public static int ToLife(this string str)
        {
            //La string reçue est la réponse à une requête HTTP, on ne conserve qu'une partie
            str = str.Substring(19, str.Length - 22);

            int result;

            //Si le cast de la string en int est impossible ou si le résultat est supérieur ou égale à 100 (Format de vie)
            if (!((Int32.TryParse(str, out result)) && (result < 100)))
            {
                //Alors une FormatLifeException est levée
                throw new FormatLifeException(str);
            }
            
            return result;
        }
    }
}
