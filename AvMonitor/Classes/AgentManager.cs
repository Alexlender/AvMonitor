using System.Net;

namespace AvMonitor.Classes
{
    public class AgentManager
    {
        private static AgentManager? _instance;
        private Uri AgentAbsoluteUri { get; set; }
        private AgentManager(string url)
        {
            AgentAbsoluteUri = new(url);
        }

        public static AgentManager GetInstance(string url)
        {
            if (_instance == null)
                _instance = new AgentManager(url);
            return _instance;
        }

        public static AgentManager GetInstance()
        {
            return _instance;
        }

        public async Task<HttpStatusCode> PostAsync(string requestPath, object content)
        {
            var httpClient = new HttpClient();
            Console.WriteLine(AgentAbsoluteUri + requestPath);
            var response = await httpClient.PostAsJsonAsync(AgentAbsoluteUri + requestPath, content);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteAsync(string requestPath)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(AgentAbsoluteUri + requestPath);
            return response.StatusCode;
        }

    }
}
