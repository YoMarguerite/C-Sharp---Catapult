using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Catapulte.Classe;

namespace Catapulte.Package
{
    class Program
    {
        static void Main(string[] args)
        {

            HTTP http = new HTTP("groupe12", "FFHPkR5V");
            Catapult catapult = new Catapult();

            bool proceed;

            do
            {
                List<int> vie_elements = new List<int>();

                foreach (Element element in catapult.Elements)
                {
                    vie_elements.Add(http.GetLife(element.Name));
                }

                catapult.PrepaTir(vie_elements);                

                proceed = false;

                if (catapult.Verif())
                {
                    proceed = true;
                    if (catapult.needHeal())
                    {
                        http.PostHeal("groupe3");
                    }
                    else
                    {
                        http.PostFire((int)catapult.Tir(), "groupe3");
                    }
                }

                System.Threading.Thread.Sleep(1500);

            } while (proceed);

        }
    }
}
