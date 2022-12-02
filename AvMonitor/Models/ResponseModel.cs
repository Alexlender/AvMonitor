using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AvMonitor.Models
{
    [Keyless]
    public class ResponseModel
    {
        
        public string TaskId { get; }

        public bool IsSuccess { get; }
        public HttpStatusCode StatusCode { get; }
        public string DateTime { get; }

        public ResponseModel()
        {
            TaskId = "";
            StatusCode = 0;
            DateTime = System.DateTime.Now.ToString();
            IsSuccess = false;
        }
        public ResponseModel(HttpStatusCode statusCode, string taskId)
        {
            TaskId = taskId;
            StatusCode = statusCode;
            DateTime = System.DateTime.Now.ToString();
            IsSuccess = StatusCode == HttpStatusCode.OK;
        }

        public override string ToString()
        {
            return $"{TaskId} {StatusCode} {DateTime}";
        }

    }
}
