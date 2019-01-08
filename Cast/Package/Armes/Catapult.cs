using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Package
{
    public struct Rock
    {
        public int Weight;
        public int Width;
    }

    class Catapult : ArmeDeJet
    {
        private Rock rock;
        private double power;

        public Catapult()
        {
            elements = new Element[] { new Spoon(), new Rope(), new Trigger(), new Arm(), new Beam() };
            elements[0].Name = "Spoon";
            elements[1].Name = "Rope";
            elements[2].Name = "Trigger";
            elements[3].Name = "Arm";
            elements[4].Name = "Beam";

            rock = new Rock();
        }

        public override void PrepaTir(List<int> vie_elements)
        {            
            for(int i =0; i < elements.Length; i++)
            {
                elements[i].Life = vie_elements[i];
            }

            Random rand = new Random();

            rock.Width = rand.Next( 4 , 8 );
            rock.Weight = rand.Next( 3 , 5 );

            Console.WriteLine("Chief, Catapult is Preparing !");
        }

        public override double Tir()
        {
            power = rock.Weight * rock.Width;

            foreach(Element element in elements)
            {
                element.Action();
            }

            Console.WriteLine("Chief, Catapult is firing !");
                
            return power;
        }

        public override bool Verif()
        {
            bool verif = true;

            foreach(Element element in elements)
            {
                if (!element.checklife())
                {
                    verif = false;
                }
            }

            if (verif)
            {
                Console.WriteLine("Chief, Catapult is ready !");
                return true;
            }
            Console.WriteLine("Chief, hum ... Catapult is destroy !");
            return false;
        }

        public bool needHeal()
        {
            double moyenne;
            double somme = 0;

            foreach (Element element in elements)
            {
                somme += element.Life;
            }
            moyenne = somme / elements.Length;

            if(moyenne <= 50)
            {
                Console.WriteLine("Chief, Catapult need some Reparation !");
                return true;
            }
            Console.WriteLine("Chief, Catapult can Attack !");
            return false;
        }
    }
}
