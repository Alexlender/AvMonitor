using AvMonitor.Models;
using System.Net;
namespace Agent.Classes
{
    public static class Pinger
    {
        static public int Ping(Uri uri)
        {
            // Creates an HttpWebRequest for the specified URL. 
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            if (myHttpWebResponse.StatusCode == HttpStatusCode.OK) //аналог 200 в перечислении
                return 1;
            else
                return -1;
        }
    }
}
