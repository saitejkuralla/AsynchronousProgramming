using System;
using System.Threading.Tasks;

namespace Onfailure
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://example.com/data";
            await RetrieveAsync(url).OnFailure(ex => Console.WriteLine($"Failed to retrieve data: {ex.Message}"));
            Console.WriteLine("hello");
        }

        public static async Task OnFailure(this Task task, Action<Exception> onFailure)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                onFailure(ex);
            }
        }

        private static async Task<string> RetrieveAsync(string url)
        {
            await Task.Delay(3000).ConfigureAwait(false);
            throw new Exception("Failed to retrieve data from server");
          
        }
    }
}
