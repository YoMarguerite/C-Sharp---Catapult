using System;

//Interface Ibreakable

namespace Catapulte.Package
{
    //Déclaration des delegate isBreak , isReady
    public delegate void isBreak();
    public delegate void isReady();

    //Ibreakable est une interface, un modèle de classe voué à être implémentée par les classes l'implémentant
    interface Ibreakable
    {
        //Propriété Life
        int Life { get; set; }

        Boolean checklife();
    }
}
