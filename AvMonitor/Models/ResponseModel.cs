using System.Net;

namespace AvMonitor.Models
{
    public class ResponseModel
    {
        public ResponseModel(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            DateTime = DateTime.Now;
        }
        public HttpStatusCode StatusCode { get; }

        public DateTime DateTime { get; }

    }
}
