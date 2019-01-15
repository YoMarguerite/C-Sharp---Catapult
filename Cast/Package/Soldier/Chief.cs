using Cast.Package.Exceptions;
using System;

//Classe Chief

namespace Cast.Package.Soldier
{
    //Chief hérite de la classe Commander composée de Catapultor
    class Chief : Commander<Catapultor>
    {
        //Constructeur de Chief, appel au constructeur de la classe mère
        public Chief() : base () {  }

        //Méthode StartSoldier qui modifie l'implémentation de la méthode abstraite héritée, on initialise un soldier avant de le return
        protected override Catapultor StartSoldier()
        {
            //On choisit un soldier dans la liste soldiers
            int index = -1;
            do
            {
                Console.WriteLine("Who will work :");
                string soldat = Console.ReadLine();

                try
                {
                    index = int.Parse(soldat);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            } while ((index < 0) || (index > soldiers.Count - 1));

            Catapultor soldier = soldiers[index];

            //On lui définit une cible
            bool cibledefine;
            string cible;
            do
            {
                cibledefine = true;
                Console.WriteLine("Define a cible :");
                cible = Console.ReadLine();

                if (!((cible == "groupe7") || (cible == "groupe8") || (cible == "groupe9") || (cible == "groupe10") || (cible == "groupe11") || (cible == "groupe12")))
                {
                    cibledefine = false;
                }

            } while (!cibledefine);

            soldier.Cible = cible;

            //On le fait travailler
            try
            {
                soldier.setWork(true);
            }
            catch (NullCibleException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return soldier;
        }

        //Méthode Execution qui modifie l'implémentation de la méthode abstraite héritée
        protected override void Execution()
        {
            //Initialisation du soldier
            Catapultor soldier = StartSoldier();

            //Boucle permettant de choicir une action
            do
            {
                soldier.Status();
                Console.WriteLine("Choose an action, cible:"+soldier.Cible+" , automatic:on/off , fire or heal:fire/heal, fin to quit");

                string action = Console.ReadLine();

                if ((action == "groupe7") || (action == "groupe8") || (action == "groupe9") || (action == "groupe10") || (action == "groupe11") || (action == "groupe12"))
                {
                    soldier.Cible = action;
                }

                if(action == "on")
                {
                    soldier.Automatic = true;
                }else if (action == "off")
                {
                    soldier.Automatic = false;
                }

                if (action == "fire")
                {
                    soldier.Fire = true;
                }
                else if (action == "heal")
                {
                    soldier.Fire = false;
                }

                if(action == "fin")
                {
                    setWork(false);
                }

            } while (work);

            //Fin du traitement
            soldier.setWork(false);
            Console.WriteLine("Chief is sleeping...");
        }
    }
}
