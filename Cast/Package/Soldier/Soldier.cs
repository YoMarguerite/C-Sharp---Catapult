using System.Threading;

//Classe Soldier

namespace Cast.Package.Soldier
{
    //Classe abstraite Soldier
    public abstract class Soldier
    {
        //Déclaration des variables d'instances
        protected bool work;
        protected Thread threadExecution;

        //Constructeur de Soldier
        protected Soldier()
        {
            //Initialisation/Instanciation des variables d'instances
            work = false;
            threadExecution = new Thread(Execution);
        }

        //Propriété Work, accesseur de la variable work
        public bool Work
        {
            get { return work; }
        }

        //Méthode virtual setWork réutilisées/réimplémentées dans les classes filles
        public virtual void setWork(bool _work)
        {
            work = _work;
            if (work)
            {
                if (!threadExecution.IsAlive)
                {
                    threadExecution.Start();
                }
            }
        }

        //Déclaration de la méthode abstraite Execution réutilisée dans les classes filles
        protected abstract void Execution();
    }
}
