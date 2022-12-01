using System.Net;

namespace AvMonitor.Models
{
    public class ResponseModel
    {
        public string TaskId { get; }
        public HttpStatusCode StatusCode { get; }
        public string DateTime { get; }
        public ResponseModel(HttpStatusCode statusCode, string taskId)
        {
            TaskId= taskId;
            StatusCode = statusCode;
            DateTime = System.DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return $"{TaskId} {StatusCode} {DateTime}";
        }

    }
}
