using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Cast.Package.Exceptions;
using Cast.Package.Extensions;

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

        public int GetLife(String target)
        {
            try
            {
                HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("https://dev18504.service-now.com/api/20557/catapulte/getlife2?target="+target);
                Req.Method = "GET"; 
                String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

                Req.Headers.Add("Authorization", "Basic " + encoded);

                Sr = new StreamReader(((HttpWebResponse)Req.GetResponse()).GetResponseStream());
                Reponse = Sr.ReadToEnd(); 
                
            }
            catch (Exception e) // En cas d'exception
            {
                Console.WriteLine(e.Message + "\r\n\r\nL'appel au serveur a echoué...");
                
            }
            finally
            {
                Sr.Close(); // Et on ferme le stream
            }

            int vie = -1;
            try
            {
                 vie = Reponse.ToLife();
            }
            catch (FormatLifeException e)
            {
                Console.WriteLine(e.Message);
            }

            return vie;
        }

        public void PostFire(int power, string target)
        {
            try
            {
                string url = "https://dev18504.service-now.com/api/20557/catapulte/fire"; // Just a sample url
                WebClient wc = new WebClient();

                wc.QueryString.Add("power", power.ToString());
                wc.QueryString.Add("target", target);

                String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

                wc.Headers.Add("Authorization", "Basic " + encoded);

                var data = wc.UploadValues(url, "POST", wc.QueryString);

                var responseString = UnicodeEncoding.UTF8.GetString(data);
                Console.WriteLine(responseString);

            }
            catch (Exception e) // En cas d'exception
            {
                Console.WriteLine(e.Message + "\r\n\r\nL'appel au serveur a echoué...");

            }
        }

        public void PostHeal(string target)
        {
            try
            {

                string url = "https://dev18504.service-now.com/api/20557/catapulte"; // Just a sample url
                WebClient wc = new WebClient();

                wc.QueryString.Add("target", target);

                String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

                wc.Headers.Add("Authorization", "Basic " + encoded);

                var data = wc.UploadValues(url, "POST", wc.QueryString);

                var responseString = UnicodeEncoding.UTF8.GetString(data);
                Console.WriteLine(responseString);

            }
            catch (Exception e) // En cas d'exception
            {
                Console.WriteLine(e.Message + "\r\n\r\nL'appel au serveur a echoué...");

            }
        }
    }
}
