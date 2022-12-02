using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AvMonitor.Models
{
    public class ResponseModel
    {
        private int _id;
        [Key]
        public int ID
        {
            get { return _id; }
        }
        public string TaskId { get; }
        public HttpStatusCode StatusCode { get; }
        public string DateTime { get; }

        public ResponseModel()
        {
            TaskId = "";
            StatusCode = 0;
            DateTime = System.DateTime.Now.ToString();
        }
        public ResponseModel(HttpStatusCode statusCode, string taskId)
        {
            TaskId = taskId;
            StatusCode = statusCode;
            DateTime = System.DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return $"{TaskId} {StatusCode} {DateTime}";
        }

    }
}
