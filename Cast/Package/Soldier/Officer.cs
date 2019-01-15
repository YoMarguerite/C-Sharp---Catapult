using System;

//Classe Officer

namespace Cast.Package.Soldier
{
    //Officer hérite de Soldier
    public abstract class Officer : Soldier
    {
        //Déclaration des variables d'instance de la classe Soldier
        protected bool automatic;
        protected bool fire;
        protected string cible;

        //Constructeur de Officer appel du constructeur de la classe mère
        protected Officer() : base()
        {
            //Initialisation des variables d'instances
            automatic = true;
            fire = true;
            cible = null;
        }

        //Propriété Automatic, accesseur et mutateur de la variable automatic
        public bool Automatic
        {
            get { return automatic; }
            set { automatic = value; }
        }

        //Propriété Fire, accesseur et mutateur de la variable fire
        public bool Fire
        {
            get { return fire; }
            set { fire = value; }
        }

        //Propriété Cible, accesseur et mutateur de la variable cible
        public string Cible
        {
            get { return cible; }
            set { cible = value; }
        }

        //Méthode virtual Status réutilisées/réimplémentées dans les classes filles
        public virtual void Status()
        {
            string work_str;
            if (work)
            {
                work_str = "i'm Working";
            }
            else
            {
                work_str = "i'm not Working";
            }

            string automatic_str;
            if (automatic)
            {
                automatic_str = "i decide by myself";
            }
            else
            {
                
                automatic_str = "i follow our orders";
            }


            Console.WriteLine("Chief, " + work_str + " , " + automatic_str + " , my cible is " + cible);
        }

    }
}
