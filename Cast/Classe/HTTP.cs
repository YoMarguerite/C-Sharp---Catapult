using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Catapulte.Classe
{
    class HTTP
    {
        private String username;
        private String password;
        private String Reponse;
        private StreamReader Sr;

        public HTTP(String user, String mdp)
        {
            this.username = user;
            this.password = mdp;
            this.Reponse = String.Empty;
            this.Sr = null;
        }

        public int Get(String target)
        {
            try
            {
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("https://dev18504.service-now.com/api/20557/catapulte/getlife2?target="+target);
                Req.Method = "GET"; // POST ou GET
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

                Req.Headers.Add("Authorization", "Basic " + encoded);
                Req.ContentType = "application/x-www-form-urlencoded"; // La plupart du temps

                Sr = new StreamReader(((HttpWebResponse)Req.GetResponse()).GetResponseStream());
                Reponse = Sr.ReadToEnd(); // On choppe la réponse
                Sr.Close(); // Et on ferme
            }
            catch (Exception e) // En cas d'exception
            {
                Console.WriteLine(e.Message + "\r\n\r\nL'appel au serveur a echoué...");
                
            }

            return RecupInt(Reponse);
        }

        public int RecupInt(string str)
        {
            MatchCollection matchCollection = Regex.Matches(str, @"\b\d+\b");

            List<int> ExtractedInt = new List<int>();
            int result;
            foreach (Match match in matchCollection)
            {
                result = int.Parse(match.Value);
                ExtractedInt.Add(result);
            }

            result = 0;

            for(int i = 0; i < ExtractedInt.Count; i++)
            {
                result += ExtractedInt[i] * (ExtractedInt.Count - i); 
            }

            return result;
        }

        public void Post(double power)
        {
            try
            {
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("https://dev18504.service-now.com/api/20557/catapulte/attack?target=" + power);
                Req.Method = "POST"; // POST ou GET
                String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

                Req.Headers.Add("Authorization", "Basic " + encoded);
                Req.ContentType = "application/x-www-form-urlencoded"; // La plupart du temps

                Sr = new StreamReader(((HttpWebResponse)Req.GetResponse()).GetResponseStream());
                Reponse = Sr.ReadToEnd(); // On choppe la réponse
                Sr.Close(); // Et on ferme
            }
            catch (Exception e) // En cas d'exception
            {
                Console.WriteLine(e.Message + "\r\n\r\nL'appel au serveur a echoué...");

            }
        }
    }
}
