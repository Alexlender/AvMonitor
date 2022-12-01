using AvMonitor.Models;
using System;
using System.Net;
namespace Agent.Classes
{
    public static class Pinger
    {
        static public ResponseModel Ping(Uri uri, string taskId = "default")
        {
            if (!uri.IsAbsoluteUri)
                throw new ArgumentException("uri must be absolute");
            HttpWebRequest myHttpWebRequest = WebRequest.CreateHttp(uri); //короче просто сделай так, чтобы возвращался реальный код ответа. Если не найден - 404 и всё такое.
            //Отправляет HttpWebRequest и ждёт ответ в виде response
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            ResponseModel RM = new ResponseModel(myHttpWebResponse.StatusCode, taskId);
            return RM;
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
