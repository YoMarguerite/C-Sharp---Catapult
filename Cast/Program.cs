using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Cast.Classe
{
    class Program
    {
        static void Main(string[] args)
        {
            //### CAST 

            //int nombre = 45;
            //float nb = nombre;

            //float nb2 = 3.5544f;
            //nombre = (int)nb2;

            //Console.WriteLine(nb);
            //Console.WriteLine(nombre);
            //Console.WriteLine(10.0 / 3);


            //### Classe avec élément privée

            //Test coucou = new Test("ici", 5);
            //Console.WriteLine(coucou.getnom()+" : "+coucou.getmat());


            //### ArmeDeJet
            //Catapulte cata = new Catapulte();
            //cata.Tirer(5);
            //cata.Tirer("un boulet de 250000 ToNNE");


            HTTP http = new HTTP("groupe12", "FFHPkR5V");
            Console.WriteLine(http.Get("Spoon"));
            Console.WriteLine(http.Get("Rope"));
            Console.WriteLine(http.Get("Beam"));
            Console.WriteLine(http.Get("Arm"));
            Console.WriteLine(http.Get("Body"));
            Console.WriteLine(http.Get("Trigger"));

            Console.ReadKey();


        }

    }
}
