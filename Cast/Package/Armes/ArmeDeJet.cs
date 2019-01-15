using System.Collections.Generic;

//Classe ArmeDeJet

namespace Catapulte.Package
{
    //ArmeDeJet est une classe abstraite générique
    public abstract class ArmeDeJet<T>
    {
        //Tableau générique des éléments composant l'ArmeDeJet
        protected T[] elements;

        //Accesseur du tableau des éléments
        public T[] Elements
        {
            get { return elements; }
        }

        //Déclaration des méthodes abstraites réutilisées dans les classes filles
        public abstract void PrepaTir(List<int> vie_elements);

        public abstract double Tir();

        public abstract bool Verif();

    }
}
