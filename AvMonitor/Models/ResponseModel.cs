using System.Net;

namespace AvMonitor.Models
{
    public class ResponseModel
    {
        public string TaskId { get; }
        public HttpStatusCode StatusCode { get; }
        public DateTime DateTime { get; }

        public ResponseModel(HttpStatusCode statusCode, string taskId = "default")
        {
            TaskId= taskId;
            StatusCode = statusCode;
            DateTime = DateTime.Now;
        }

        

    }
}
