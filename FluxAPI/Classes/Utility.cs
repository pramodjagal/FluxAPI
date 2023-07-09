using System;
using System.Net;
using System.Threading.Tasks;

namespace FluxAPI.Classes
{
    public static class Utility
    {
        internal static WebClient webClient = new WebClient();

        private static Uri ToUri(string url)
        {
            var toUri = new Uri(url);
            return toUri;
        }

        public static async Task DownloadAsync(string url, string name)
        {
            await webClient.DownloadFileTaskAsync(ToUri(url), name);
        }

        public static void Cw(string cwMsg)
        {
            Console.WriteLine("[ " + DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss") + " ] " + cwMsg);
        }
    }
}
