namespace AvMonitor.Classes
{
    public class Caller
    {
        public void SendMessage(string channel, string message)
        {
            Console.WriteLine($"#{channel}# => {message}");
        }

    }
}
