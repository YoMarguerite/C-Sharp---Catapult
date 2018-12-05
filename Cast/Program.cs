using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Catapulte.Classe
{
    class Program
    {
        static void Main(string[] args)
        {
            HTTP http = new HTTP("groupe12", "FFHPkR5V");
            Catapult catapult = new Catapult();

            catapult.PrepaTir(http.Get("spoon"), http.Get("rope"), http.Get("trigger"), http.Get("arm"), http.Get("beam"));
            if (catapult.Tir())
            {

            }

            Console.ReadKey();
        }
    }
}
