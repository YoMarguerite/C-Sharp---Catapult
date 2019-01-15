using System;
using System.Collections.Generic;

//Classe Catapult

namespace Catapulte.Package
{
    //Structure Rock définissant le projectile de la catapulte
    public struct Rock
    {
        public int Weight;
        public int Width;
    }

    //Catapult hérite de la classe ArmeDeJet composée d'éléments de la classe Element
    class Catapult : ArmeDeJet<Element>
    {
        //Déclaration des variables d'instances rock , power
        protected Rock rock;
        protected double power;

        //Constructeur de Catapult, initialise le tableau d'éléments
        public Catapult()
        {
            elements = new Element[] { new Spoon(), new Rope(), new Trigger(), new Arm(), new Beam() };
            elements[0].Name = "Spoon";
            elements[1].Name = "Rope";
            elements[2].Name = "Trigger";
            elements[3].Name = "Arm";
            elements[4].Name = "Beam";

            foreach (var item in elements)
            {
                void InitEventBreak() { Console.WriteLine("Chief, " + item.Name + " is Break !"); }
                item.EventBreak += InitEventBreak;

                void InitEventReady() { Console.WriteLine("Chief, " + item.Name + " is Ready !"); }
                item.EventReady += InitEventReady;
            }
        }

        //Méthode d'initialisation de rock
        protected int InitRock()
        {
            Random rand = new Random();
            this.rock = new Rock();

            this.rock.Width = rand.Next(4, 8);
            this.rock.Weight = 40 / this.rock.Width;
            return this.rock.Weight * this.rock.Width;
        }

        //Méthode PrepaTir qui modifie l'implémentation de la méthode abstraite héritée
        public override void PrepaTir(List<int> vie_elements)
        {   
            //On définit la vie des éléments
            for(int i =0; i < elements.Length; i++)
            {
                elements[i].Life = vie_elements[i];
            }

            //On définit la variable power
            this.power = InitRock();                //CAST IMPLICIT

            Console.WriteLine("Chief, Catapult is Preparing !");
        }

        //Méthode Tir qui modifie l'implémentation de la méthode abstraite héritée
        public override double Tir()
        {                      
            //On execute la méthode Action de chaque Element contenus dans éléments
            foreach(var item in elements)
            {
                item.Action();
            }

            Console.WriteLine("Chief, Catapult is firing !");
            
            //On return la variable power
            return power;
        }

        //Méthode Verif qui modifie l'implémentation de la méthode abstraite héritée
        public override bool Verif()
        {
            //On vérifie que la méthode checklife de chaque Element, return true
            bool verif = true;

            foreach(var item in elements)
            {
                if (!item.checklife())
                {
                    verif = false;
                }
            }

            //Si tout les Element de éléments return true
            if (verif)
            {
                Console.WriteLine("Chief, Catapult is Ready !");
                return true;
            }

            //Sinon
            Console.WriteLine("Chief, hum ... Catapult is Destroy !");
            return false;
        }

        //Méthode needHeal qui return true si la moyenne de vie des Element est inférieur ou égale à 50
        public bool needHeal()
        {
            //Calcul de la moyenne de la vie des Element
            double moyenne;
            double somme = 0;

            foreach (var item in elements)
            {
                somme += item.Life;
            }
            moyenne = somme / elements.Length;

            //Si moyenne est inférieur ou égale à 50
            if(moyenne <= 50)
            {
                Console.WriteLine("Chief, Catapult need some Reparation !");
                return true;
            }

            //Sinon
            Console.WriteLine("Chief, Catapult can Attack !");
            return false;
        }
    }
}
