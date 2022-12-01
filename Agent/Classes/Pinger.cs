using AvMonitor.Models;
using System;
using System.Net;
namespace Agent.Classes
{
    public static class Pinger
    {
        static public ResponseModel Ping(Uri uri)
        {
            // Создаёт HttpWebRequest объект для URL
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            //Отправляет HttpWebRequest и ждёт ответ в виде response
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            ResponseModel RM = new ResponseModel(myHttpWebResponse.StatusCode);
            return RM;
        }
    }
}
