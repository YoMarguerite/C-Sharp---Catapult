using System;

//Classe Spoon

namespace Catapulte.Package
{
    //Spoon hérite de la classe Element
    class Spoon : Element
    {
        //Méthode Action qui modifie l'implémentation de la méthode abstraite héritée
        public override void Action()
        {
            Console.WriteLine("Chief, Rock is Load !");
        }
    }
}
