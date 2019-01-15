using Cast.Package.Exceptions;
using Cast.Package.Extensions;
using Cast.Package.Requêtes;
using Catapulte.Package;
using System;
using System.Collections.Generic;

//Classe Catapultor

namespace Cast.Package.Soldier
{
    //Catapultor hérite de Officer
    class Catapultor : Officer
    {
        //Déclaration de la variable d'instance catapult
        protected Catapult catapult;

        //Constructeur de Catapultor, on appel le constructeur de la classe mère
        public Catapultor() : base()
        {
            //Instanciation de catapult
            catapult = new Catapult();
        }

        //Méthode setWork qui modifie l'implémentation de la méthode abstraite héritée
        public override void setWork(bool _work)
        {
            work = _work;
            if (work)
            {
                //Si la cible est définie
                if(cible != null)
                {
                    Console.WriteLine("Chief, i'm Working !");

                    //Si le threadExecution n'est pas lancé, Alors on le démarre
                    if (!threadExecution.IsAlive)
                    {
                        threadExecution.Start();
                    }
               
                }
                else
                {
                    //Sinon on lève une NullCibleException
                    throw new NullCibleException();
                }
            }
        }

        //Méthode Status qui modifie l'implémentation de la méthode abstraite héritée
        public override void Status()
        {
            //Appel de la Méthode Status de la classe mère
            base.Status();

            string fire_str;
            if (fire)
            {
                fire_str = "I fire";
            }
            else
            {
                fire_str = "I heal";
            }

            //On affiche le status du Catapultor
            Console.WriteLine(fire_str + " , my cible : " + cible);
        }

        //Méthode Status qui modifie l'implémentation de la méthode abstraite héritée
        protected override void Execution()
        {
            do
            {
                Maintenance();
                Action();

            } while (work);//Tant que work égale true

            Console.WriteLine("Soldier is sleeping...");
        }

        //Méthode Maintenance 
        protected void Maintenance()
        {
            List<int> vie_elements = new List<int>();

            //On définie la vie de chaque Element
            foreach (var item in catapult.Elements)
            {
                //Try car une exception peut-être levée
                try
                {
                    //Appel GET vers le serveur
                    vie_elements.Add(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/getlife2?target=" + item.Name, "GET").GetResponse().ToLife());

                }
                catch (FormatLifeException e)
                {
                    //Traitement lorsqu'une FormatLifeException a été levée
                    Console.WriteLine(e.Message);
                    vie_elements.Add(-1);
                }
                catch(Exception e)
                {
                    //Traitement lorsqu'une Exception a été levée
                    Console.WriteLine(e.Message);
                    vie_elements.Add(-1);
                }
            }

            //Appel de la méthode PrepaTir
            catapult.PrepaTir(vie_elements);
        }

        //Method Action
        protected void Action()
        {
            //Si la méthode Verif de catapult est true
            if (catapult.Verif())
            {
                //Si automatic est true
                if (automatic)
                {
                    //Si catapult.needHeal est true
                    if (catapult.needHeal())
                    {
                        //Appel au serveur POST pour heal
                        Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/heal", "POST", "target=" + this.cible).GetResponse());
                    }
                    else
                    {
                        //Appel au serveur POST pour fire
                        Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/fire", "POST", "power=" + ((int)catapult.Tir()).ToString() + "&target=" + this.cible).GetResponse());
                    }
                }
                else
                {
                    //Sinon

                    //Si fire est false
                    if (!fire)
                    {
                        //Appel au serveur POST pour heal
                        Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/heal", "POST", "target=" + this.cible).GetResponse());
                    }
                    else
                    {
                        //Appel au serveur POST pour fire
                        Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/fire", "POST", "power=" + ((int)catapult.Tir()).ToString() + "&target=" + this.cible).GetResponse());
                    }
                }
            }
        }

    }
}
