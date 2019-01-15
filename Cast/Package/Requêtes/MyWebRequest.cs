using System;
using System.IO;
using System.Net;
using System.Text;

//Classe MyWebRequest

namespace Cast.Package.Requêtes
{
    //MyWebRequest est une classe permettant d'effectuer des requêtes HTTP, GET ou POST
    public class MyWebRequest
    {
        //Déclaration des variables d'instance
        private WebRequest request;
        private Stream dataStream;

        private string status;
        private readonly string username = "groupe12";
        private readonly string password = "FFHPkR5V";

        //Propriété Status, mutateur et accesseur de status
        public String Status
        {
            get{ return status; }
            set{ status = value; }
        }

        //Constructeur de MyWebRequest
        public MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

        //Seconde implémentation du Constructeur de MyWebRequest
        public MyWebRequest(string url, string method)
            : this(url)
        {
            //Encodage des données pour autoriser la requête
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

            request.Headers.Add("Authorization", "Basic " + encoded);

            //Si method est égale à "GET" ou "POST"
            if (method.Equals("GET") || method.Equals("POST"))
            {
                //Alors on définit la methode de la requête
                request.Method = method;
            }
            else
            {
                //Sinon on lève une Exception
                throw new Exception("Invalid Method Type");
            }
        }

        //Troisième implémentation du Constructeur de MyWebRequest
        public MyWebRequest(string url, string method, string postData)
            : this(url, method)
        {
            // Encodage des données à POST
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);


            //Définition du ContentType
            request.ContentType = "application/x-www-form-urlencoded";


            //Définition du ContentLength
            request.ContentLength = byteArray.Length;


            //Accès au flux de la requête
            dataStream = request.GetRequestStream();


            //Ecriture des données dans le flux de la requête
            dataStream.Write(byteArray, 0, byteArray.Length);


            //On ferme le flux
            dataStream.Close();

        }

        //Méthode GetResponse permettant d'obtenir la réponse du serveur à la requête
        public string GetResponse()
        {
            string responseFromServer = null;

            try
            {
                //On obtient la réponse d'origine
                WebResponse response = request.GetResponse();
                this.Status = ((HttpWebResponse)response).StatusDescription;

                //On obtient le flux de la réponse du serveur
                dataStream = response.GetResponseStream();

                //On ouvre le flux
                StreamReader reader = new StreamReader(dataStream);

                //Lecture du flux jusqu'à la fin
                responseFromServer = reader.ReadToEnd();

                //Fermeture des flux
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch(WebException e)
            {
                //Si l'obtention de la réponse du serveur échoue on lève une WebException
                Console.WriteLine(e.Message);
            }
            
            return responseFromServer;
        }

    }
}
