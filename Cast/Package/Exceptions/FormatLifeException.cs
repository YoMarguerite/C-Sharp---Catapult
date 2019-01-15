using System;

//Classe FormatLifeException

namespace Cast.Package.Exceptions
{
    //FormatLifeException hérite de la classe FormatException
    public class FormatLifeException : FormatException
    {
        //Constructeur de FormatLifeException, on appel le constructeur de la classe mère avec en paramètre une string personnalisée
        public FormatLifeException(string valeur) : base("FormatLifeException : La valeur récupérez : " + valeur + " ne correponds pas à la vie d'un élément.") {}
    }
}
