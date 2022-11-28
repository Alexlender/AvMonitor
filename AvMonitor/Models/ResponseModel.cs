using System.Net;

namespace AvMonitor.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; }

        public DateTime DateTime { get; }

    }
}
