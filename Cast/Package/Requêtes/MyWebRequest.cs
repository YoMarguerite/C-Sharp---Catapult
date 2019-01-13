using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cast.Package.Requêtes
{
    public class MyWebRequest
    {
        private WebRequest request;
        private Stream dataStream;

        private string status;
        private readonly string username = "groupe12";
        private readonly string password = "FFHPkR5V";

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

        public MyWebRequest(string url, string method)
            : this(url)
        {
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

            request.Headers.Add("Authorization", "Basic " + encoded);

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public MyWebRequest(string url, string method, string data)
            : this(url, method)
        {
            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            
            request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();

        }

        public string GetResponse()
        {
            string responseFromServer = null;
            // Get the original response.
            try
            {
                WebResponse response = request.GetResponse();
                this.Status = ((HttpWebResponse)response).StatusDescription;

                // Get the stream containing all content returned by the requested server.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content fully up to the end.
                responseFromServer = reader.ReadToEnd();

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch(WebException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return responseFromServer;
        }

    }
}
