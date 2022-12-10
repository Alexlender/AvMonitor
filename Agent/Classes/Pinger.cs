using AvMonitor.Models;
using System;
using System.Net;


namespace Agent.Classes
{
    public static class Pinger
    {

        static HttpClient httpClient = new HttpClient();
        static public ResponseModel Ping(Uri uri, string taskId = "default")
        {
            try
            {
                if (!uri.IsAbsoluteUri)
                    throw new ArgumentException("uri must be absolute");
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri); //короче просто сделай так, чтобы возвращался реальный код ответа. Если не найден - 404 и всё такое.
                using HttpResponseMessage response = httpClient.SendAsync(request).Result;                                                                                               //Отправляет HttpWebRequest и ждёт ответ в виде response

                ResponseModel RM = new ResponseModel(response.StatusCode, taskId);
                return RM;
            }
            catch (Exception) 
            {
                ResponseModel RME = new ResponseModel(HttpStatusCode.NotFound, taskId);
                return RME;
            }

        }

        static public ResponseModel Ping(TaskModel task)
        {
            return Ping(task.Path, task.Id);
        }

        static public ResponseModel Ping(string path, string taskId = "default")
        {
            Uri uri = new Uri(path, UriKind.RelativeOrAbsolute);
            uri = uri.IsAbsoluteUri ? uri : new Uri($"http://{uri.OriginalString}");
            return Ping(uri, taskId);
        }
    }
}
