using System;

//Classe Rope

namespace Catapulte.Package
{
    //Rope hérite de la classe Element
    class Rope : Element
    {
        //Méthode Action qui modifie l'implémentation de la méthode abstraite héritée
        public override void Action()
        {
            Console.WriteLine("Chief, Rope is Tight !");
        }
    }
}
