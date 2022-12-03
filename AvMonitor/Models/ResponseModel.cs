using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AvMonitor.Models
{

    public class ResponseModel
    {
        [Key]
        public int Index { get; set; }

        public string TaskId { get; set; }

        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string DateTime { get; set; }

        public ResponseModel() { }
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
