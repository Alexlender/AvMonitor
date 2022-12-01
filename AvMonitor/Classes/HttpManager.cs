using System.Net;

namespace AvMonitor.Classes
{
    public class HttpManager
    {
        private static HttpManager? _instance;
        private Uri AgentAbsoluteUri { get; set; }
        private HttpManager(string url)
        {
            AgentAbsoluteUri = new(url);
        }

        public static HttpManager Init(string url)
        {
            if (_instance == null)
                _instance = new HttpManager(url);
            return _instance;
        }

        public static HttpManager GetInstance()
        {
            if(_instance != null)
                return _instance;
            throw new NullReferenceException("Object is not initialized");
        }

        public async Task<HttpResponseMessage> PostAsync(string requestPath, object content)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(AgentAbsoluteUri + requestPath, content);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestPath)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(AgentAbsoluteUri + requestPath);
            return response;
        }

    }
}
