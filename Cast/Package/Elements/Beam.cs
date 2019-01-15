using System;

//Classe Beam

namespace Catapulte.Package
{
    //Beam hérite de la classe Element
    class Beam : Element
    {
        //Méthode Action qui modifie l'implémentation de la méthode abstraite héritée
        public override void Action()
        {
            Console.WriteLine("Chief, Beam correctly stop the Arm !");
        }
    }
}
