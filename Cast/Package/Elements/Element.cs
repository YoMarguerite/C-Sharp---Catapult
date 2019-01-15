using System;

//Classe Element

namespace Catapulte.Package
{
    //Element est une classe abstraite qui implémente l'interface Ibreakable
    public abstract class Element : Ibreakable
    {
        //Déclaration des event EventBreak , EventReady
        public event isBreak EventBreak;
        public event isReady EventReady;

        //Déclaration des variables d'instances name , vie
        protected String name;
        protected int vie;

        //Propriété Life, accesseur et mutateur de la variable vie
        public int Life
        {
            get { return vie;  }
            set { vie = value; }
        }

        //Propriété Name, accesseur et mutateur de la variable name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Déclaration de la méthode abstract Action réutilisée dans les classes filles
        public abstract void Action();

        //Méthode checklife qui return true si vie est supérieur ou égale à 0
        public Boolean checklife()
        {
            //Si vie est supérieur ou égale à 0
            if (vie >= 0)
            {
                //Si EventReady est différent de null, alors on appel l'event 
                if (EventReady != null) { EventReady(); }
                return true;
            }
            //Sinon

            //Si EventBreak est différent de null, alors on appel l'event 
            if (EventBreak != null) { EventBreak(); }
            return false;
        }
    }
}
