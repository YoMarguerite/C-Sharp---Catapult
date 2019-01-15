using System;
using System.Collections.Generic;

//Classe Commander

namespace Cast.Package.Soldier
{
    //Commander est une classe abstraite générique qui hérite de Soldier
    public abstract class Commander<T> : Soldier
    {
        //Déclaration de la liste générique soldiers
        protected List<T> soldiers;

        //Constructeur de Commander, appel du constructeur de la classe mère
        protected Commander() : base()
        {
            //Initialisation de soldiers
            soldiers = new List<T>();
        }

        //Méthode hireSoldier qui ajoute un soldier à la liste soldiers
        public void hireSoldier()
        {
            T soldier = (T)Activator.CreateInstance(typeof(T));
            soldiers.Add(soldier);
        }

        //Déclaration de la méthode abstraite StartSoldier réutilisée dans les classes filles
        protected abstract T StartSoldier();
    }
}
