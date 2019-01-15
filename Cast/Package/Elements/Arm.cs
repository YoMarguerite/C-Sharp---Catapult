using System;

//Classe Arm

namespace Catapulte.Package
{
    //Arm hérite de la classe Element
    class Arm : Element
    {
        //Méthode Action qui modifie l'implémentation de la méthode abstraite héritée
        public override void Action()
        {
            Console.WriteLine("Chief, Arm is launching the Spoon !");
        }
    }
}
