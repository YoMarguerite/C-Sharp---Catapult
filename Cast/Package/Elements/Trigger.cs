using System;

//Classe Element

namespace Catapulte.Package
{
    //Trigger hérite de la classe Element
    class Trigger : Element
    {
        //Méthode Action qui modifie l'implémentation de la méthode abstraite héritée
        public override void Action()
        {
            Console.WriteLine("Chief, Trigger is Fire !");
        }
    }
}
