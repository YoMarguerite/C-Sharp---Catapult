using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Net;
using System.IO;
using Catapulte.Classe;
using Cast.Package.Requêtes;
using Cast.Package.Extensions;
using Cast.Package.Exceptions;

namespace Catapulte.Package
{
    class Program
    {
        static Catapult catapult = new Catapult();
        static bool proceed = true;

        static void Main(string[] args)
        {

            
            new Thread(Execution).Start();


            while (proceed)
            {
                string saisie = Console.ReadLine();
                if(saisie == "fin")
                {
                    proceed = false;
                }
            }
            

        }

        static void Action()
        {

        }

        static void Execution()
        {
            //HTTP http = new HTTP("groupe12", "FFHPkR5V");
            

            do
            {
                List<int> vie_elements = new List<int>();

                foreach (Element element in catapult.Elements)
                {
                    try
                    {
                        vie_elements.Add(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/getlife2?target=" + element.Name, "GET").GetResponse().ToLife());

                    } catch(FormatLifeException e)
                    {
                        Console.WriteLine(e.Message);
                        vie_elements.Add(-1);
                    }
                }

                catapult.PrepaTir(vie_elements);

                //proceed = false;

                if (catapult.Verif())
                {
                    Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/fire", "POST", "power=20&target=groupe10").GetResponse());
                    Console.WriteLine(new MyWebRequest("https://dev18504.service-now.com/api/20557/catapulte/heal", "POST", "target=groupe10").GetResponse());
                    //proceed = true;
                    //if (catapult.needHeal())
                    //{
                    //http.PostHeal("groupe10");
                    //}
                    //else
                    //{
                    //http.PostFire((int)catapult.Tir(), "groupe10");
                    //}
                    //string URI = "https://dev18504.service-now.com/api/20557/catapulte/heal";
                    //string myParameters = "Rope";

                    //using (WebClient wc = new WebClient())
                    //{
                    //    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    //    string HtmlResult = wc.UploadString(URI, myParameters);
                    //    Console.WriteLine(HtmlResult);
                    //}
                }

                //Thread.Sleep(1000);

            } while (proceed);
        }
    }
}
